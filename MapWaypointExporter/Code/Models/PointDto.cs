using ProtoBuf;

namespace MapWaypointExporter.Code.Models;

[ProtoContract]
public class Coordinates
{
    [ProtoMember(1)]
    public double X { get; set; }

    [ProtoMember(2)]
    public double Y { get; set; }

    [ProtoMember(3)]
    public double Z { get; set; }
}
