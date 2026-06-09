using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAssistenciaTecnicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class OrcamentoNovo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Orcamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_FuncionarioId",
                table: "Orcamento",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Funcionario_FuncionarioId",
                table: "Orcamento",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Funcionario_FuncionarioId",
                table: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_FuncionarioId",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Orcamento");
        }
    }
}
