using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_2022.Migrations
{
    public partial class Carts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdCart",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCart",
                table: "Orders",
                column: "IdCart");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_IdCart",
                table: "Orders",
                column: "IdCart",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_IdCart",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdCart",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdCart",
                table: "Orders");
        }
    }
}
