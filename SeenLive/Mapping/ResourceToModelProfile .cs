using AutoMapper;
using SeenLive.Models;
using SeenLive.Resources;

namespace SeenLive.Mapping
{
    public class ResourceToModelProfile
        : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<BandResourceCreate, Band>();
        }
    }
}
