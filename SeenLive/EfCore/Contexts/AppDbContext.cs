using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;
using SeenLive.EfCore.Seeders;
using SeenLive.Events;
using SeenLive.Locations;
using SeenLive.Users;
using SeenLive.Visits;

namespace SeenLive.EfCore.Contexts;

public class AppDbContext
    : IdentityDbContext<User>
{
    public DbSet<CountryEntity> Countries => Set<CountryEntity>();
    public DbSet<CityEntity> Cities => Set<CityEntity>();
    public DbSet<LocationEntity> Locations => Set<LocationEntity>();
    public DbSet<BandEntity> Bands => Set<BandEntity>();
    public DbSet<EventEntity> Events => Set<EventEntity>();
    public new DbSet<User> Users => Set<User>();
    public DbSet<VisitEntity> Visits => Set<VisitEntity>();

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
            
        builder.SeedLocationsData();
        builder.SeedBandsData();
        builder.SeedEventsData();
    }
}