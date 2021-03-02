using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeenLive.Migrations
{
    public partial class Rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlternativeNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BandEntityEventEntity",
                columns: table => new
                {
                    BandsId = table.Column<int>(type: "int", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandEntityEventEntity", x => new { x.BandsId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_BandEntityEventEntity_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandEntityEventEntity_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandEntityEventEntity_EventsId",
                table: "BandEntityEventEntity",
                column: "EventsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandEntityEventEntity");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
