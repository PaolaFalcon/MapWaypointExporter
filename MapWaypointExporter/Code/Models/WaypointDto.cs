using ProtoBuf;
using System.Collections.Generic;

namespace MapWaypointExporter.Code.Models;

[ProtoContract]
public class SharedWaypoint
{
    [ProtoMember(1)]
    public Coordinates Position { get; set; }

    [ProtoMember(2)]
    public string Title { get; set; }

    [ProtoMember(3)]
    public int Color { get; set; }

    [ProtoMember(4)]
    public string Icon { get; set; }

    [ProtoMember(5)]
    public bool ShowInWorld;

    [ProtoMember(6)]
    public string OwningPlayerUid = null;

    [ProtoMember(7)]
    public int OwningPlayerGroupId = -1;

    [ProtoMember(8)]
    public HashSet<string> Pins = new HashSet<string>();

    [ProtoMember(9)]
    public bool AllowOthersToEdit = true;

    [ProtoMember(12)]
    public string Guid { get; set; }

    [ProtoMember(10)]
    public string PlayerName; // client only

    [ProtoMember(11)]
    public int Index; // client only
}