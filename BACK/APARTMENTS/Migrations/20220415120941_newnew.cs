using Microsoft.EntityFrameworkCore.Migrations;

namespace APARTMENTS.Migrations
{
    public partial class newnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Apartments_RentedApartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RentedApartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RentedApartmentId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_RenterId",
                table: "Apartments",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_RenterId",
                table: "Apartments",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_RenterId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_RenterId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Apartments");

            migrationBuilder.AddColumn<int>(
                name: "RentedApartmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RentedApartmentId",
                table: "AspNetUsers",
                column: "RentedApartmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Apartments_RentedApartmentId",
                table: "AspNetUsers",
                column: "RentedApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }
    }
}
