using SeenLive.Models;
using SeenLive.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Services
{
    public interface IBandService
    {
        Task<IEnumerable<BandResourceShort>> ListAsync();
        Task<Band> FindByIdAsync(int id);
        Task<Band> FindByIdWithEventsAsync(int id);
    }
}
