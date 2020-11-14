using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookProject.Data.Migrations
{
    public partial class noteAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AddressRecord",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "AddressRecord",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "AddressRecord");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AddressRecord",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
