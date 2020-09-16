using System.ComponentModel.DataAnnotations;

namespace SeenLive.Resources
{
    public class BandResourceCreate
    {
        [Required]
        public string Name { get; set; }

        public string AlternativeNames { get; set; }

        public string Info { get; set; }

    }
}
