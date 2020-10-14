using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EEApi.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "createPeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_createPeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeaImg = table.Column<string>(nullable: true),
                    organizationName = table.Column<string>(nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    UpdTime = table.Column<DateTime>(nullable: false),
                    CId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "createPeople");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
