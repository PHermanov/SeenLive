using SeenLive.Models;
using System.Collections.Generic;

namespace SeenLive.Resources
{
    public class BandResourceFull
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AlternativeNames { get; set; }

        public string Info { get; set; }

        public ICollection<EventResource> Events { get; set; }
    }
}
