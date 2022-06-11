using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;

namespace SeenLive.EfCore.Seeders;

public static class BandsSeeder
{
    public static void SeedBandsData(this ModelBuilder builder)
    {
        builder.Entity<BandEntity>().HasData(
            new BandEntity {Id = 1, Name = "Clawfinger", Info = "Sweden"},
            new BandEntity {Id = 2, Name = "Брати Гадюкіни", Info = "Ukraine"},
            new BandEntity {Id = 3, Name = "Anti-Flag", Info = "USA"},
            new BandEntity {Id = 4, Name = "Ляпис Трубецкой", Info = "Belarus", AlternativeNames = "Ляпіс Трубецкой"},
            new BandEntity {Id = 5, Name = "Noize MC", Info = "Russia"},
            new BandEntity {Id = 6, Name = "Zdob si Zdub", Info = "Moldova", AlternativeNames = "Zdob şi Zdub"},
            new BandEntity {Id = 7, Name = "Скрябін", Info = "Ukraine"},
            new BandEntity {Id = 8, Name = "ТНМК", Info = "Ukraine", AlternativeNames = "Танок на майдані Конго"},
            new BandEntity {Id = 9, Name = "Тартак", Info = "Ukraine"},
            new BandEntity {Id = 10, Name = "Rocky Leon", Info = "Austria"},
            new BandEntity {Id = 11, Name = "Перкалаба", Info = "Ukraine"},
            new BandEntity {Id = 12, Name = "Карна", Info = "Ukraine"},
            new BandEntity {Id = 13, Name = "КораЛЛі", Info = "Ukraine", AlternativeNames = "Кораллі"},
            new BandEntity {Id = 14, Name = "Петрос", Info = "Ukraine"},
            new BandEntity {Id = 15, Name = "Воплі Відоплясова", Info = "Ukraine", AlternativeNames = "ВВ"},
            new BandEntity {Id = 16, Name = "Триставісім", Info = "Ukraine"},
            new BandEntity {Id = 17, Name = "Dimicandum", Info = "Ukraine"},
            new BandEntity {Id = 18, Name = "Caliban", Info = "Germany"},
            new BandEntity {Id = 19, Name = "Ektomorf", Info = "Hungary"},
            new BandEntity {Id = 20, Name = "Роллікс", Info = "Ukraine"},
            new BandEntity {Id = 21, Name = "Тостер", Info = "Ukraine"},
            new BandEntity {Id = 22, Name = "Тінь Сонця", Info = "Ukraine"},
            new BandEntity {Id = 23, Name = "Фліт", Info = "Ukraine"},
            new BandEntity {Id = 24, Name = "Jinjer", Info = "Ukraine"},
            new BandEntity {Id = 25, Name = "Skinhate", Info = "Ukraine"},
            new BandEntity {Id = 26, Name = "Ratbite", Info = "Ukraine"},
            new BandEntity {Id = 27, Name = "Sciana ", Info = "Belarus"},
            new BandEntity {Id = 28, Name = "Molfa", Info = "Ukraine"},
            new BandEntity {Id = 29, Name = "The Crawls", Info = "Ukraine"},
            new BandEntity {Id = 30, Name = "Bandurband", Info = "Ukraine"},
            new BandEntity {Id = 31, Name = "Blood Brothers", Info = "Ukraine"},
            new BandEntity {Id = 32, Name = "Latur", Info = "Ukraine"},
            new BandEntity {Id = 33, Name = "Серцевий напад", Info = "Ukraine"},
            new BandEntity {Id = 34, Name = "Flunk", Info = "Norway"},
            new BandEntity {Id = 35, Name = "I Am Waiting For You Last Summer", Info = "Russia"},
            new BandEntity {Id = 36, Name = "Крихітка", Info = "Ukraine"},
            new BandEntity {Id = 37, Name = "the Retuses", Info = "Russia"},
            new BandEntity {Id = 38, Name = "Qarpa", Info = "Ukraine"},
            new BandEntity {Id = 39, Name = "Один в каное", Info = "Ukraine"},
            new BandEntity {Id = 40, Name = "The ВЙО", Info = "Ukraine"},
            new BandEntity {Id = 41, Name = "Фіолет", Info = "Ukraine"},
            new BandEntity {Id = 42, Name = "Vivienne Mort", Info = "Ukraine"},
            new BandEntity {Id = 43, Name = "Плесо", Info = "Ukraine"},
            new BandEntity {Id = 44, Name = "Гич Оркестр", Info = "Ukraine"},
            new BandEntity {Id = 45, Name = "Acloneofmyown", Info = "Ukraine"},
            new BandEntity {Id = 46, Name = "Maiak", Info = "Ukraine"},
            new BandEntity {Id = 47, Name = "Lakeway", Info = "Ukraine"},
            new BandEntity {Id = 48, Name = "My Atlas", Info = "Ukraine"},
            new BandEntity {Id = 49, Name = "Dakh Daughters", Info = "Ukraine"},
            new BandEntity {Id = 50, Name = "Illusions", Info = "Ukraine"},
            new BandEntity {Id = 51, Name = "Zapaska", Info = "Ukraine"},
            new BandEntity {Id = 52, Name = "DrumТиатр", Info = "Ukraine"},
            new BandEntity {Id = 53, Name = "O.Torvald", Info = "Ukraine"}
            );
    }
}