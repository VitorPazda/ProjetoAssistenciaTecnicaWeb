using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAssistenciaTecnicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FuncionarioId",
                table: "Produto",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Funcionario_FuncionarioId",
                table: "Produto",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Funcionario_FuncionarioId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_FuncionarioId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Produto");
        }
    }
}
