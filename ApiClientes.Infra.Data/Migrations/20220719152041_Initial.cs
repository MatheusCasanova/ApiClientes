using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClientes.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DATANASCIMENTO = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IDCLIENTE);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_CPF",
                table: "CLIENTE",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_EMAIL",
                table: "CLIENTE",
                column: "EMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
