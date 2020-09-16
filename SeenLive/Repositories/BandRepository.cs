using Microsoft.EntityFrameworkCore;
using SeenLive.Models;
using SeenLive.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeenLive.Repositories
{
    public class BandRepository
        : BaseRepository, IBandRespository
    {
        public BandRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task<Band> FindByIdAsync(int id)
        {
            return await _context.Bands.FindAsync(id);
        }

        public async Task<Band> FindByIdWithEventsAsync(int id)
        {
            return await _context.Bands
                .Include(be => be.BandEvents)
                .ThenInclude(e => e.Event)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Band>> ListAsync()
        {
            return await _context.Bands.ToListAsync();
        }
    }
}
