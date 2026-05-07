using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAssistenciaTecnicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class _0705TesteProduto3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ClienteId",
                table: "Produto",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Cliente_ClienteId",
                table: "Produto",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Cliente_ClienteId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_ClienteId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Produto");
        }
    }
}
