using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_CarRentalTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpLocationId",
                table: "CarRentals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationId",
                table: "CarRentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
