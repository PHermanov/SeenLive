using SeenLive.Models;
using SeenLive.Resources;
using SeenLive.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Services
{
    public interface IBandService
    {
        Task<IEnumerable<Band>> ListAsync();
        Task<Band> FindByIdAsync(int id);
        Task<Band> FindByIdWithEventsAsync(int id);
        Task<SaveBandResponce> AddAsync(Band band);
    }
}
