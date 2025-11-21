using System.Text.Json;
using System.Text.Json.Serialization;

namespace MapWaypointExporter.Code.Configurations
{
    public static class SerializerConfiguration
    {
        public static readonly JsonSerializerOptions JsonSerializerDefaultOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
    }
}