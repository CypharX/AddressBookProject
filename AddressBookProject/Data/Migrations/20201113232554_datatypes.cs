using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookProject.Data.Migrations
{
    public partial class datatypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "AddressRecord",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "AddressRecord",
                type: "int",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
