using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAssistenciaTecnicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoOrdemServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "OrdemServico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_FuncionarioId",
                table: "OrdemServico",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Funcionario_FuncionarioId",
                table: "OrdemServico",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Funcionario_FuncionarioId",
                table: "OrdemServico");

            migrationBuilder.DropIndex(
                name: "IX_OrdemServico_FuncionarioId",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "OrdemServico");
        }
    }
}
