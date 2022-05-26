using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeContas.ContasBancarias.Migrations
{
    public partial class AjusteNoNomeDaTabelaContas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Agencias_AgenciaId",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Clientes_ClienteId",
                table: "Conta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conta",
                table: "Conta");

            migrationBuilder.RenameTable(
                name: "Conta",
                newName: "Contas");

            migrationBuilder.RenameIndex(
                name: "IX_Conta_ClienteId",
                table: "Contas",
                newName: "IX_Contas_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Conta_AgenciaId",
                table: "Contas",
                newName: "IX_Contas_AgenciaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Agencias_AgenciaId",
                table: "Contas",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_ClienteId",
                table: "Contas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Agencias_AgenciaId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_ClienteId",
                table: "Contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.RenameTable(
                name: "Contas",
                newName: "Conta");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_ClienteId",
                table: "Conta",
                newName: "IX_Conta_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_AgenciaId",
                table: "Conta",
                newName: "IX_Conta_AgenciaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conta",
                table: "Conta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Agencias_AgenciaId",
                table: "Conta",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Clientes_ClienteId",
                table: "Conta",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
