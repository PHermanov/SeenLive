using System.ComponentModel;

namespace SeenLive.Events
{
    public enum EventType
        : byte
    {
        [Description("Festival")]
        Festival,
        [Description("Solo event")]
        Solo
    }
}
