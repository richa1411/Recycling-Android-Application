using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kymiraAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Resident",
               columns: table => new
               {
                   ID = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   password = table.Column<string>(maxLength: 50, nullable: false),
                   phoneNumber = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Resident", x => x.ID);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Resident");
        }
    }
}
