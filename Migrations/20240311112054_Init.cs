using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBooking.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightDetail",
                columns: table => new
                {
                    AeroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fare = table.Column<float>(type: "real", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetail", x => x.AeroId);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AeroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingDetail_FlightDetail_AeroId",
                        column: x => x.AeroId,
                        principalTable: "FlightDetail",
                        principalColumn: "AeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetail_PassengerDetail_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "PassengerDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_AeroId",
                table: "BookingDetail",
                column: "AeroId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_PassengerId",
                table: "BookingDetail",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetail");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FlightDetail");

            migrationBuilder.DropTable(
                name: "PassengerDetail");
        }
    }
}
