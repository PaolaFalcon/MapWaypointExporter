using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWaypointExporter.assets.Extensions;

public static class ColorExtensions
{
    public static string ToHexString(this int color)
    {
        uint unsignedArgb = unchecked((uint)color);
        return $"#{unsignedArgb:X8}";
    }
}
