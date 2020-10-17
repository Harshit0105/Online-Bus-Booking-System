using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusBooking.Migrations
{
    public partial class BusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Bus_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Souce_City = table.Column<string>(nullable: false),
                    Destination_City = table.Column<string>(nullable: false),
                    Number_Of_Seats = table.Column<int>(nullable: false),
                    Source_Time = table.Column<DateTime>(nullable: false),
                    Destination_Time = table.Column<DateTime>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Bus_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Bus_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");
        }
    }
}
