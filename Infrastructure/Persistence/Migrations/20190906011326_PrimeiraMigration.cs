using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteFullStackPleno.Infrastructure.Persistence.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "db_Comportamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true),
                    Parametros = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_Comportamento", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "db_Comportamento");
        }
    }
}
