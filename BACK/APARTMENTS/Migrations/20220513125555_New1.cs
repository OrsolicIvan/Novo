using Microsoft.EntityFrameworkCore.Migrations;

namespace APARTMENTS.Migrations
{
    public partial class New1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Apartments_ApartmentId",
                table: "Adresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Apartments_ApartmentId",
                table: "Adresses",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Apartments_ApartmentId",
                table: "Adresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Apartments_ApartmentId",
                table: "Adresses",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
