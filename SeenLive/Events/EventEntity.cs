using SeenLive.Bands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeenLive.Events
{
    public class EventEntity
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }
        public EventType EventType { get; set; }
        public ICollection<BandEntity> Bands { get; set; }
        public EventViewModel ToViewModel()
            => new() { Id = Id, Name = Name, Date = Date };
    }
}
