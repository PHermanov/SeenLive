using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SeenLive.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }
        public EventType EventType { get; set; }
        public ICollection<BandEvent> BandEvents { get; set; }
    }
}
