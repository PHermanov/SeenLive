using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;
using SeenLive.Events;

namespace SeenLive.Persistence.Contexts
{
    public class AppDbContext
        : DbContext
    {
        public DbSet<BandEntity> Bands { get; set; }
        public DbSet<EventEntity> Events { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
