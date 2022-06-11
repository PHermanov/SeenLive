using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeenLive.Api.Migrations
{
    public partial class seedevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "AlternativeNames", "Info", "Name" },
                values: new object[,]
                {
                    { 1, null, "Sweden", "Clawfinger" },
                    { 2, null, "Ukraine", "Брати Гадюкіни" },
                    { 3, null, "USA", "Anti-Flag" },
                    { 4, "Ляпіс Трубецкой", "Belarus", "Ляпис Трубецкой" },
                    { 5, null, "Russia", "Noize MC" },
                    { 6, "Zdob şi Zdub", "Moldova", "Zdob si Zdub" },
                    { 7, null, "Ukraine", "Скрябін" },
                    { 8, "Танок на майдані Конго", "Ukraine", "ТНМК" },
                    { 9, null, "Ukraine", "Тартак" },
                    { 10, null, "Austria", "Rocky Leon" },
                    { 11, null, "Ukraine", "Перкалаба" },
                    { 12, null, "Ukraine", "Карна" },
                    { 13, "Кораллі", "Ukraine", "КораЛЛі" },
                    { 14, null, "Ukraine", "Петрос" },
                    { 15, "ВВ", "Ukraine", "Воплі Відоплясова" },
                    { 16, null, "Ukraine", "Триставісім" },
                    { 17, null, "Ukraine", "Dimicandum" },
                    { 18, null, "Germany", "Caliban" },
                    { 19, null, "Hungary", "Ektomorf" },
                    { 20, null, "Ukraine", "Роллікс" },
                    { 21, null, "Ukraine", "Тостер" },
                    { 22, null, "Ukraine", "Тінь Сонця" },
                    { 23, null, "Ukraine", "Фліт" },
                    { 24, null, "Ukraine", "Jinjer" },
                    { 25, null, "Ukraine", "Skinhate" },
                    { 26, null, "Ukraine", "Ratbite" },
                    { 27, null, "Belarus", "Sciana " },
                    { 28, null, "Ukraine", "Molfa" },
                    { 29, null, "Ukraine", "The Crawls" },
                    { 30, null, "Ukraine", "Bandurband" },
                    { 31, null, "Ukraine", "Blood Brothers" },
                    { 32, null, "Ukraine", "Latur" },
                    { 33, null, "Ukraine", "Серцевий напад" },
                    { 34, null, "Norway", "Flunk" },
                    { 35, null, "Russia", "I Am Waiting For You Last Summer" },
                    { 36, null, "Ukraine", "Крихітка" },
                    { 37, null, "Russia", "the Retuses" },
                    { 38, null, "Ukraine", "Qarpa" },
                    { 39, null, "Ukraine", "Один в каное" },
                    { 40, null, "Ukraine", "The ВЙО" },
                    { 41, null, "Ukraine", "Фіолет" },
                    { 42, null, "Ukraine", "Vivienne Mort" },
                    { 43, null, "Ukraine", "Плесо" },
                    { 44, null, "Ukraine", "Гич Оркестр" },
                    { 45, null, "Ukraine", "Acloneofmyown" },
                    { 46, null, "Ukraine", "Maiak" },
                    { 47, null, "Ukraine", "Lakeway" },
                    { 48, null, "Ukraine", "My Atlas" },
                    { 49, null, "Ukraine", "Dakh Daughters" },
                    { 50, null, "Ukraine", "Illusions" },
                    { 51, null, "Ukraine", "Zapaska" },
                    { 52, null, "Ukraine", "DrumТиатр" },
                    { 53, null, "Ukraine", "O.Torvald" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 6, 1, "Rodatychy" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityId", "CountryId", "Name" },
                values: new object[] { 5, 6, 1, "Charivna Dolyna" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "EventType", "Info", "LocationId", "Name" },
                values: new object[] { 1, new DateTime(2014, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), (byte)1, null, 5, "Zaxidfest 2014" });

            migrationBuilder.Sql(File.ReadAllText(Path.Combine("..","SeenLive", "EfCore", "Seeders", "SeedZaxidfest2014.sql")));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);
            
            migrationBuilder.Sql(File.ReadAllText(Path.Combine("..","SeenLive", "EfCore", "Seeders","RemoveSeedZaxidfest2014.sql")));
        }
    }
}
