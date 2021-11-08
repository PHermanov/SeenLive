using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;
using SeenLive.Events;
using SeenLive.Users;

namespace SeenLive.EfCore.Contexts
{
    public class AppDbContext
        : IdentityDbContext<User>
    {
        public DbSet<BandEntity> Bands => Set<BandEntity>();
        public DbSet<EventEntity> Events => Set<EventEntity>();
        public new DbSet<User> Users  => Set<User>();
        
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public AppDbContext()
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        } 
    }
}
