using MapWaypointExporter.Code.Configurations;
using MapWaypointExporter.Code.Extensions;
using MapWaypointExporter.Code.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Util;

namespace MapWaypointExporter.Code.Services;

public class MapWaypointExporterService
{
    private readonly ICoreServerAPI coreServerApi;

    public MapWaypointExporterService(ICoreServerAPI api)
    {
        this.coreServerApi = api;
    }

    public void Initialize()
    {
        this.coreServerApi.Event.GameWorldSave += OnSaveGameGettingSaved;
    }

    public void OnSaveGameGettingSaved()
    {
        this.WriteCurrentWaypoints();
    }

    private void WriteCurrentWaypoints()
    {
        byte[] data = coreServerApi.WorldManager.SaveGame.GetData(Constants.WorldManagerSharedWaypointsData);
        if (data != null)
        {
            Dictionary<string, List<SharedWaypoint>> waypoints = SerializerUtil.Deserialize<Dictionary<string, List<SharedWaypoint>>>(data);
            string serialized = JsonSerializer.Serialize(waypoints, SerializerConfiguration.JsonSerializerDefaultOptions);

            foreach (string key in waypoints.Keys)
            {
                coreServerApi.Logger.Notification($"Player {key} has {waypoints[key].Count} waypoints.");
                foreach (var waypoint in waypoints[key])
                {
                    coreServerApi.Logger.Notification($" - Waypoint {waypoint.Title} at ({waypoint.Position.X}, {waypoint.Position.Y}, {waypoint.Position.Z}) color {waypoint.Color.ToHexString()}");
                }
            }

            string directory = "ModConfig/MapWaypointExporter";
            string directoryPath = Path.Combine(this.coreServerApi.DataBasePath, directory);
            Directory.CreateDirectory(directoryPath);
            string filePath = Path.Combine(directoryPath, "map_waypoints.json");
            File.WriteAllText(filePath, serialized);
        }
    }
}