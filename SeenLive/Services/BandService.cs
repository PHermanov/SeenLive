using AutoMapper;
using FluentValidation;
using SeenLive.Models;
using SeenLive.Persistence.Repositories;
using SeenLive.Persistence.Repositories.Bands;
using SeenLive.Resources;
using SeenLive.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Services
{
    public class BandService
        : IBandService
    {
        private readonly IBandRespository _bandRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IValidator _validator;

        public BandService(IBandRespository bandRepository, IUnitOfWork unitOfWork)
        {
            _bandRepository = bandRepository;
            _unitOfWork = unitOfWork;
          //  _validator = validator;
        }

        public async Task<Band> FindByIdAsync(int id)
        {
            return await _bandRepository.FindByIdAsync(id);
        }

        public async Task<Band> FindByIdWithEventsAsync(int id)
        {
            return await _bandRepository.FindByIdWithEventsAsync(id);
        }

        public async Task<IEnumerable<Band>> ListAsync()
        {
            var bands = await _bandRepository.ListAsync();
            return bands;
        }

        public async Task<SaveBandResponce> AddAsync(Band band)
        {
          

            await _bandRepository.AddAsync(band);
            await _unitOfWork.CompleteAsync();

            return new SaveBandResponce(band);
        }
    }
}
