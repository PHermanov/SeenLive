using SeenLive.Bands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SeenLive.Persistence.Repositories.Bands
{
    public interface IBandRepository
    {
        Task<IEnumerable<BandEntity>> ListAsync();
        Task<BandEntity> FindByIdAsync(int id);
        Task<BandEntity> FindByIdWithEventsAsync(int id);
        Task<BandEntity> AddAsync(BandEntity band, CancellationToken cancellationToken);
        Task<BandEntity> UpdateAsync(BandEntity band, BandEntity updatedBand, CancellationToken cancellationToken);
        Task DeleteAsync(BandEntity band);
    }
}
