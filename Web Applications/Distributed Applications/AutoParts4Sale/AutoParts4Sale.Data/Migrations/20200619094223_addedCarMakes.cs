using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoParts4Sale.Data.Migrations
{
    public partial class addedCarMakes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoparts_CarMake_CarMakeId",
                table: "Autoparts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarMake",
                table: "CarMake");

            migrationBuilder.DropColumn(
                name: "YearMade",
                table: "CarMake");

            migrationBuilder.RenameTable(
                name: "CarMake",
                newName: "CarMakes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Autoparts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarMakes",
                table: "CarMakes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoparts_CarMakes_CarMakeId",
                table: "Autoparts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarMakes",
                table: "CarMakes");

            migrationBuilder.RenameTable(
                name: "CarMakes",
                newName: "CarMake");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Autoparts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "YearMade",
                table: "CarMake",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarMake",
                table: "CarMake",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Autoparts_CarMake_CarMakeId",
                table: "Autoparts",
                column: "CarMakeId",
                principalTable: "CarMake",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
