using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBooking.Migrations
{
    public partial class SeatTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Buses_Bus_Id1",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_Bus_Id1",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Bus_Id1",
                table: "Seats");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Bus_Id",
                table: "Seats",
                column: "Bus_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Buses_Bus_Id",
                table: "Seats",
                column: "Bus_Id",
                principalTable: "Buses",
                principalColumn: "Bus_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Buses_Bus_Id",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_Bus_Id",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "Bus_Id1",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Bus_Id1",
                table: "Seats",
                column: "Bus_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Buses_Bus_Id1",
                table: "Seats",
                column: "Bus_Id1",
                principalTable: "Buses",
                principalColumn: "Bus_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
