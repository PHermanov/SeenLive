using Microsoft.EntityFrameworkCore;
using SeenLive.Models;

namespace SeenLive.Persistence.Contexts
{
    public class AppDbContext
        : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Event> Events { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BandEvent>()
                .HasKey(be => new { be.BandId, be.EventId });
            modelBuilder.Entity<BandEvent>()
                .HasOne(be => be.Band)
                .WithMany(b => b.BandEvents)
                .HasForeignKey(bc => bc.BandId);
            modelBuilder.Entity<BandEvent>()
                .HasOne(be => be.Event)
                .WithMany(c => c.BandEvents)
                .HasForeignKey(be => be.EventId);
        }
    }
}
