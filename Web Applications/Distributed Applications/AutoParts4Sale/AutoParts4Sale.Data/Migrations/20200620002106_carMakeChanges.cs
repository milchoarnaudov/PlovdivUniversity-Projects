using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoParts4Sale.Data.Migrations
{
    public partial class carMakeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoparts_CarModel_CarModelId",
                table: "Autoparts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "CarModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarMakes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarMakeId",
                table: "CarModels",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarMakeId",
                table: "CarModels",
                column: "CarMakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autoparts_CarModels_CarModelId",
                table: "Autoparts",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarMakes_CarMakeId",
                table: "CarModels",
                column: "CarMakeId",
                principalTable: "CarMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoparts_CarModels_CarModelId",
                table: "Autoparts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarMakes_CarMakeId",
                table: "CarModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CarMakeId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CarMakeId",
                table: "CarModels");

            migrationBuilder.RenameTable(
                name: "CarModels",
                newName: "CarModel");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarMakes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Autoparts_CarModel_CarModelId",
                table: "Autoparts",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
