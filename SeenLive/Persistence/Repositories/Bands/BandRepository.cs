using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;
using SeenLive.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeenLive.Persistence.Repositories.Bands
{
    public class BandRepository
        : BaseRepository, IBandRepository
    {
        public BandRepository(AppDbContext context)
            : base(context)
        { }

        public async Task<BandEntity> FindByIdAsync(int id)
            => await _context.Bands.FindAsync(id);

        public async Task<BandEntity> FindByIdWithEventsAsync(int id)
            => await _context
                .Bands
                .Include(b => b.Events)
                .FirstOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<BandEntity>> ListAsync()
           => await _context.Bands.OrderBy(b => b.Name).ToListAsync();

        public async Task AddAsync(BandEntity band)
            => await _context.Bands.AddAsync(band);

        public void Update(BandEntity band)
            => _context.Bands.Update(band);
    }
}
