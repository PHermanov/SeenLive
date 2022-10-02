using System.ComponentModel;

namespace SeenLive.Events;

public enum EventType
    : byte
{
    [Description("Other")]
    Other,
    [Description("Festival")]
    Festival,
    [Description("Solo")]
    Solo
}