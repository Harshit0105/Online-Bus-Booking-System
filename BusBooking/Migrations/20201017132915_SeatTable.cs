using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBooking.Migrations
{
    public partial class SeatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    Seat_No = table.Column<int>(nullable: false),
                    Bus_Id = table.Column<int>(nullable: false),
                    Bus_Id1 = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Buses_Bus_Id1",
                        column: x => x.Bus_Id1,
                        principalTable: "Buses",
                        principalColumn: "Bus_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Bus_Id1",
                table: "Seats",
                column: "Bus_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UserId",
                table: "Seats",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");
        }
    }
}
