using AutoMapper;
using SeenLive.Models;
using SeenLive.Resources;
using System.Linq;

namespace SeenLive.Mapping
{
    public class ModelToResourceProfile 
        : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Event, EventResource>();

            CreateMap<Band, BandResourceShort>();
                           
            CreateMap<Band, BandResourceFull>()
                 .ForMember(d => d.Events, opt => opt.MapFrom(be => be.BandEvents.Select(e => e.Event)));
        }
    }
}
