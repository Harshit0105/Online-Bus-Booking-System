using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBooking.Migrations
{
    public partial class TableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Buses_Bus_Id",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Bus_Id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Souce_City",
                table: "Buses");

            migrationBuilder.AddColumn<int>(
                name: "Bus_Id1",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Souce_City",
                table: "Buses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Bus_Id1",
                table: "Tickets",
                column: "Bus_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Buses_Bus_Id1",
                table: "Tickets",
                column: "Bus_Id1",
                principalTable: "Buses",
                principalColumn: "Bus_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Buses_Bus_Id1",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Bus_Id1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Bus_Id1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Souce_City",
                table: "Buses");

            migrationBuilder.AddColumn<string>(
                name: "Souce_City",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Bus_Id",
                table: "Tickets",
                column: "Bus_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Buses_Bus_Id",
                table: "Tickets",
                column: "Bus_Id",
                principalTable: "Buses",
                principalColumn: "Bus_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
