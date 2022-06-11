using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;
using SeenLive.Events;

namespace SeenLive.EfCore.Seeders;

public static class EventsSeeder
{
    public static void SeedEventsData(this ModelBuilder builder)
    {
        builder.Entity<EventEntity>().HasData(
            new
            {
                Id = 1,
                Name = "Zaxidfest 2014",
                Date = new DateTime(2014, 8, 8),
                EventType = EventType.Festival,
                LocationId = 5
            });

      /*  builder.Entity("BandsEntityEventsEntity").HasData(
            new {BandsId = 1, EventsId = 1},
            new {BandsId = 2, EventsId = 1},
            new {BandsId = 3, EventsId = 1},
            new {BandsId = 4, EventsId = 1},
            new {BandsId = 5, EventsId = 1},
            new {BandsId = 6, EventsId = 1},
            new {BandsId = 7, EventsId = 1},
            new {BandsId = 8, EventsId = 1},
            new {BandsId = 9, EventsId = 1},
            new {BandsId = 10, EventsId = 1},
            new {BandsId = 11, EventsId = 1},
            new {BandsId = 12, EventsId = 1},
            new {BandsId = 13, EventsId = 1},
            new {BandsId = 14, EventsId = 1},
            new {BandsId = 15, EventsId = 1},
            new {BandsId = 16, EventsId = 1},
            new {BandsId = 17, EventsId = 1},
            new {BandsId = 18, EventsId = 1},
            new {BandsId = 19, EventsId = 1},
            new {BandsId = 20, EventsId = 1},
            new {BandsId = 21, EventsId = 1},
            new {BandsId = 22, EventsId = 1},
            new {BandsId = 23, EventsId = 1},
            new {BandsId = 24, EventsId = 1},
            new {BandsId = 25, EventsId = 1},
            new {BandsId = 26, EventsId = 1},
            new {BandsId = 27, EventsId = 1},
            new {BandsId = 28, EventsId = 1},
            new {BandsId = 29, EventsId = 1},
            new {BandsId = 30, EventsId = 1},
            new {BandsId = 31, EventsId = 1},
            new {BandsId = 32, EventsId = 1},
            new {BandsId = 33, EventsId = 1},
            new {BandsId = 34, EventsId = 1},
            new {BandsId = 35, EventsId = 1},
            new {BandsId = 36, EventsId = 1},
            new {BandsId = 37, EventsId = 1},
            new {BandsId = 38, EventsId = 1},
            new {BandsId = 39, EventsId = 1},
            new {BandsId = 40, EventsId = 1},
            new {BandsId = 41, EventsId = 1},
            new {BandsId = 42, EventsId = 1},
            new {BandsId = 43, EventsId = 1},
            new {BandsId = 44, EventsId = 1},
            new {BandsId = 45, EventsId = 1},
            new {BandsId = 46, EventsId = 1},
            new {BandsId = 47, EventsId = 1},
            new {BandsId = 48, EventsId = 1},
            new {BandsId = 49, EventsId = 1},
            new {BandsId = 50, EventsId = 1},
            new {BandsId = 51, EventsId = 1},
            new {BandsId = 52, EventsId = 1},
            new {BandsId = 53, EventsId = 1}
        ); */
    }
}