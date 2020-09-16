using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeenLive.Models
{
    public class Band
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string AlternativeNames { get; set; }

        public string Info { get; set; }
        
        public ICollection<BandEvent> BandEvents { get; set; }
    }
}
