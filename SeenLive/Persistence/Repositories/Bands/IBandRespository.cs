using SeenLive.Bands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Persistence.Repositories.Bands
{
    public interface IBandRespository
    {
        Task<IEnumerable<BandEntity>> ListAsync();
        Task<BandEntity> FindByIdAsync(int id);
        Task<BandEntity> FindByIdWithEventsAsync(int id);
        Task AddAsync(BandEntity band);
        void Update(BandEntity band);
    }
}
