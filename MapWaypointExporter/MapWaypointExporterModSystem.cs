using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace MapWaypointExporter
{
    public class MapWaypointExporterModSystem : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            Mod.Logger.Notification("Hello from template mod: " + api.Side);
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            Mod.Logger.Notification("Hello from template mod client side: " + Lang.Get("mapwaypointexporter:hello"));
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            Mod.Logger.Notification("Hello from template mod server side: " + Lang.Get("mapwaypointexporter:hello"));

            var service = new Code.Services.MapWaypointExporterService(api);
            service.Initialize();
        }
    }
}
