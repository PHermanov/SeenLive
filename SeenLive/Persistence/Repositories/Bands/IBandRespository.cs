using SeenLive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Persistence.Repositories.Bands
{
    public interface IBandRespository
    {
        Task<IEnumerable<Band>> ListAsync();
        Task<Band> FindByIdAsync(int id);
        Task<Band> FindByIdWithEventsAsync(int id);
        Task AddAsync(Band band);
    }
}
