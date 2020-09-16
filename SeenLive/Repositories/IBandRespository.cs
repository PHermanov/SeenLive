using SeenLive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Repositories
{
    public interface IBandRespository
    {
        Task<IEnumerable<Band>> ListAsync();
        Task<Band> FindByIdAsync(int id);
        Task<Band> FindByIdWithEventsAsync(int id);
    }
}
