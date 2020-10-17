using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBooking.Migrations
{
    public partial class TicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Ticket_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Bus_Id = table.Column<int>(nullable: false),
                    Travel_Date = table.Column<DateTime>(nullable: false),
                    Seat_Id = table.Column<string>(nullable: false),
                    Amount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Ticket_Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Buses_Bus_Id",
                        column: x => x.Bus_Id,
                        principalTable: "Buses",
                        principalColumn: "Bus_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Bus_Id",
                table: "Tickets",
                column: "Bus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
