using Microsoft.EntityFrameworkCore;
using SeenLive.Locations;

namespace SeenLive.EfCore.Seeders;

public static class LocationsSeeder
{
    public static void SeedLocationsData(this ModelBuilder builder)
    {
        builder.Entity<CountryEntity>().HasData(
            new CountryEntity {Id = 1, Name = "Ukraine", Code = "UA"},
            new CountryEntity {Id = 2, Name = "Germany", Code = "DE"},
            new CountryEntity {Id = 3, Name = "Poland", Code = "PL"}
            );

        builder.Entity<CityEntity>().HasData(
            new {Id = 1, Name = "Kyiv", CountryId = 1},
            new {Id = 2, Name = "Munster", CountryId = 2},
            new {Id = 3, Name = "Kharkiv", CountryId = 1},
            new {Id = 4, Name = "Katowice", CountryId = 3},
            new {Id = 5, Name = "Krakow", CountryId = 3},
            new {Id = 6, Name = "Rodatychy", CountryId = 1}
            );

        builder.Entity<LocationEntity>().HasData(
            new {Id = 1, Name = "Жара", CountryId = 1, CityId = 3},
            new {Id = 2, Name = "Stereoplaza", CountryId = 1, CityId = 1},
            new {Id = 3, Name = "Tauron Arena", CountryId = 3, CityId = 5},
            new {Id = 4, Name = "Zeppelinfeld", CountryId = 2, CityId = 2},
            new {Id = 5, Name = "Charivna Dolyna", CountryId = 1, CityId = 6}
            );
    }
}