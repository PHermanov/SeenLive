using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;
using SeenLive.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeenLive.Persistence.Repositories.Bands
{
    public class BandRepository
        :  IBandRepository
    {
        private readonly AppDbContext _context;

        public BandRepository(AppDbContext context)
            => _context = context;

        public async Task<BandEntity> FindByIdAsync(int id)
            => await _context.Bands.FindAsync(id);

        public async Task<BandEntity> FindByIdWithEventsAsync(int id)
            => await _context
                .Bands
                .Include(b => b.Events)
                .FirstOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<BandEntity>> ListAsync()
           => await _context.Bands.OrderBy(b => b.Name).ToListAsync();

        public async Task<BandEntity> AddAsync(BandEntity band, CancellationToken cancellationToken)
        {
            await _context.Bands.AddAsync(band, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return band;
        }

        public async Task<BandEntity> UpdateAsync(BandEntity band, BandEntity updatedBand, CancellationToken cancellationToken)
        {
            band.Name = updatedBand.Name;
            band.AlternativeNames = updatedBand.AlternativeNames;
            band.Info = updatedBand.Info;

            await _context.SaveChangesAsync(cancellationToken);

            band.Id = updatedBand.Id;

            return band;
        }

        public async Task DeleteAsync(BandEntity band)
        {
            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();
        }
    }
}
