using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAssistenciaTecnicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Funcionario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Funcionario");
        }
    }
}
