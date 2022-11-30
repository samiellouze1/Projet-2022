using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_2022.Migrations
{
    public partial class niwniwniw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coupons_IdCoupon",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "IdCoupon",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coupons_IdCoupon",
                table: "Orders",
                column: "IdCoupon",
                principalTable: "Coupons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coupons_IdCoupon",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "IdCoupon",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coupons_IdCoupon",
                table: "Orders",
                column: "IdCoupon",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
