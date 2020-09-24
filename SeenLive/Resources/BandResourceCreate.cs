using System.ComponentModel.DataAnnotations;

namespace SeenLive.Resources
{
    public class BandResourceCreate
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string AlternativeNames { get; set; }

        public string Info { get; set; }

    }
}
