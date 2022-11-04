using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteUPD8.Data.Migrations
{
    public partial class removendo_tabela_sexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Clientes",
                newName: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "clienteId");
        }
    }
}
