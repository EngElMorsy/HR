using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Infrustructure.Migrations
{
    public partial class CrtEditName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DisName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cloths");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MagSide",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "JobPart",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "jobFinal",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "District",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Depart",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Country",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Company",
                newName: "NameEN");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "City",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Branch",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Sizes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Sizes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "MagSide",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "JobPart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "jobFinal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "District",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Depart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Cloths",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Cloths",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "MagSide");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "JobPart");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "jobFinal");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "District");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Depart");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Cloths");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Cloths");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "City");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "MagSide",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "JobPart",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "jobFinal",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "District",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Depart",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Country",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEN",
                table: "Company",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "City",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Branch",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sizes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DisName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cloths",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
