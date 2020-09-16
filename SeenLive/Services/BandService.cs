using AutoMapper;
using SeenLive.Models;
using SeenLive.Repositories;
using SeenLive.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Services
{
    public class BandService
        : IBandService
    {
        private readonly IBandRespository _bandRepository;
        private readonly IMapper _mapper;

        public BandService(IBandRespository bandRepository, IMapper mapper)
        {
            _bandRepository = bandRepository;
            _mapper = mapper;
        }

        public async Task<Band> FindByIdAsync(int id)
        {
            return await _bandRepository.FindByIdAsync(id);
        }

        public async Task<Band> FindByIdWithEventsAsync(int id)
        {
            return await _bandRepository.FindByIdWithEventsAsync(id);
        }

        public async Task<IEnumerable<BandResourceShort>> ListAsync()
        {
            var bands = await _bandRepository.ListAsync();
            return _mapper.Map<IEnumerable<BandResourceShort>>(bands);
        }
    }
}
