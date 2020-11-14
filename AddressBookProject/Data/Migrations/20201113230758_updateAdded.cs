using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookProject.Data.Migrations
{
    public partial class updateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Updated",
                table: "AddressRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                table: "AddressRecord");
        }
    }
}
