using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAssistenciaTecnicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoPeca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Peca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Peca_FuncionarioId",
                table: "Peca",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peca_Funcionario_FuncionarioId",
                table: "Peca",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peca_Funcionario_FuncionarioId",
                table: "Peca");

            migrationBuilder.DropIndex(
                name: "IX_Peca_FuncionarioId",
                table: "Peca");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Peca");
        }
    }
}
