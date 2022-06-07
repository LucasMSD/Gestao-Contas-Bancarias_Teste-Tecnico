using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeContas.ContasBancarias.Migrations
{
    public partial class MudandoCamposParaNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Contas_ContaDestinoId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Contas_ContaOrigemId",
                table: "Movimentacoes");

            migrationBuilder.AlterColumn<long>(
                name: "ContaOrigemId",
                table: "Movimentacoes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ContaDestinoId",
                table: "Movimentacoes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Contas_ContaDestinoId",
                table: "Movimentacoes",
                column: "ContaDestinoId",
                principalTable: "Contas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Contas_ContaOrigemId",
                table: "Movimentacoes",
                column: "ContaOrigemId",
                principalTable: "Contas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Contas_ContaDestinoId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Contas_ContaOrigemId",
                table: "Movimentacoes");

            migrationBuilder.AlterColumn<long>(
                name: "ContaOrigemId",
                table: "Movimentacoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ContaDestinoId",
                table: "Movimentacoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Contas_ContaDestinoId",
                table: "Movimentacoes",
                column: "ContaDestinoId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Contas_ContaOrigemId",
                table: "Movimentacoes",
                column: "ContaOrigemId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
