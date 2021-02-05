﻿using SeenLive.Events;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeenLive.Bands
{
	public class BandEntity
	{
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		[MaxLength(100)]
		public string Name { get; set; }
		public string AlternativeNames { get; set; }
		public string Info { get; set; }
		public ICollection<EventEntity> Events { get; set; }
	}
}