using AutoMapper;

namespace SeenLive.Bands
{
	public class BandMapperProfile
		: Profile
	{
		public BandMapperProfile()
		{
			CreateMap<BandResourceCreate, BandEntity>();
			CreateMap<BandEntity, BandResourceShort>();
			CreateMap<BandEntity, BandResourceFull>();
		}
	}
}
