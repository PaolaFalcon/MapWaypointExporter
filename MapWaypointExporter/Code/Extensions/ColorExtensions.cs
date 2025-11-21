namespace MapWaypointExporter.Code.Extensions;

public static class ColorExtensions
{
    public static string ToHexString(this int color)
    {
        uint unsignedArgb = unchecked((uint)color);
        return $"#{unsignedArgb:X8}";
    }
}
