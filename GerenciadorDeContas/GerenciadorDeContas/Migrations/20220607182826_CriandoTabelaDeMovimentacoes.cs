using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeContas.ContasBancarias.Migrations
{
    public partial class CriandoTabelaDeMovimentacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContaDestinoId = table.Column<long>(type: "bigint", nullable: false),
                    ContaDestinoNumero = table.Column<long>(type: "bigint", nullable: true),
                    ContaOrigemId = table.Column<long>(type: "bigint", nullable: false),
                    ContaOrigemNumero = table.Column<long>(type: "bigint", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TipoMovimentacao = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Contas_ContaDestinoId",
                        column: x => x.ContaDestinoId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Contas_ContaOrigemId",
                        column: x => x.ContaOrigemId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ContaDestinoId",
                table: "Movimentacoes",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ContaOrigemId",
                table: "Movimentacoes",
                column: "ContaOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");
        }
    }
}
