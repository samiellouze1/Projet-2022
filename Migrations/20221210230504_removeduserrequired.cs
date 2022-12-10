using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_2022.Migrations
{
    public partial class removeduserrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IdUser",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_IdUser",
                table: "Orders",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IdUser",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_IdUser",
                table: "Orders",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
