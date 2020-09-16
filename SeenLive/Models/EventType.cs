using System.ComponentModel;

namespace SeenLive.Models
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
