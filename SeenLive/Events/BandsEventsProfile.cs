using AutoMapper;
using SeenLive.Resources;

namespace SeenLive.Events
{
	public class BandsEventsProfile
		: Profile
	{
		public BandsEventsProfile()
		{
			CreateMap<EventEntity, EventResource>();
		}
	}
}
