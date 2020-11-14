using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookProject.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressRecord",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    Address1 = table.Column<string>(maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    ZipCode = table.Column<int>(maxLength: 5, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressRecord", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressRecord");
        }
    }
}
