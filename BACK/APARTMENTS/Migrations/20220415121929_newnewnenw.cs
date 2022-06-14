using Microsoft.EntityFrameworkCore.Migrations;

namespace APARTMENTS.Migrations
{
    public partial class newnewnenw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_OwnerId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_RenterId",
                table: "Apartments");

            migrationBuilder.AlterColumn<int>(
                name: "RenterId",
                table: "Apartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_OwnerId",
                table: "Apartments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_RenterId",
                table: "Apartments",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_OwnerId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_RenterId",
                table: "Apartments");

            migrationBuilder.AlterColumn<int>(
                name: "RenterId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_OwnerId",
                table: "Apartments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_RenterId",
                table: "Apartments",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
