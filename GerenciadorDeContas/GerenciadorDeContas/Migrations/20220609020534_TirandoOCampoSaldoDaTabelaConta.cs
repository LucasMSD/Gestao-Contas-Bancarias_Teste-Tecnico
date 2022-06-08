using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeContas.ContasBancarias.Migrations
{
    public partial class TirandoOCampoSaldoDaTabelaConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Contas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Contas",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
