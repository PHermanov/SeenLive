using SeenLive.Persistence.Contexts;
using System.Threading.Tasks;

namespace SeenLive.Persistence.Repositories
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) => _context = context;

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
    }
}
