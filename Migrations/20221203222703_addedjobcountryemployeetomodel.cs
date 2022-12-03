using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_2022.Migrations
{
    public partial class addedjobcountryemployeetomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdCountry",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdJob",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdManager",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdCountry",
                table: "AspNetUsers",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdJob",
                table: "AspNetUsers",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdManager",
                table: "AspNetUsers",
                column: "IdManager");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IdManager",
                table: "AspNetUsers",
                column: "IdManager",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_IdCountry",
                table: "AspNetUsers",
                column: "IdCountry",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Jobs_IdJob",
                table: "AspNetUsers",
                column: "IdJob",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IdManager",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_IdCountry",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Jobs_IdJob",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdCountry",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdJob",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdManager",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdJob",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdManager",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");
        }
    }
}
