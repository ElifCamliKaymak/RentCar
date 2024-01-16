using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_CarRentalProcessTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CarRentalProcesses",
                columns: table => new
                {
                    CarRentalProcessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropOffDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropOffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickUpLocationId = table.Column<int>(type: "int", nullable: false),
                    DropOffLocationId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentalProcesses", x => x.CarRentalProcessId);
                    table.ForeignKey(
                        name: "FK_CarRentalProcesses_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentalProcesses_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentalProcesses_Locations_DropOffLocationId",
                        column: x => x.DropOffLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarRentalProcesses_Locations_PickUpLocationId",
                        column: x => x.PickUpLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalProcesses_CarId",
                table: "CarRentalProcesses",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalProcesses_CustomerId",
                table: "CarRentalProcesses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalProcesses_DropOffLocationId",
                table: "CarRentalProcesses",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentalProcesses_PickUpLocationId",
                table: "CarRentalProcesses",
                column: "PickUpLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentalProcesses");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
