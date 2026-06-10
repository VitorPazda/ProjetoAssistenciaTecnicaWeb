using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAssistenciaTecnicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoOrdemServicoNovamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConserto",
                table: "OrdemServico",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoServicoPrestado",
                table: "OrdemServico",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "PercentualEstabelecimento",
                table: "OrdemServico",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentualTecnico",
                table: "OrdemServico",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TecnicoResponsavelId",
                table: "OrdemServico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAcrescentado",
                table: "OrdemServico",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorConsertoBase",
                table: "OrdemServico",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPecas",
                table: "OrdemServico",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_TecnicoResponsavelId",
                table: "OrdemServico",
                column: "TecnicoResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Funcionario_TecnicoResponsavelId",
                table: "OrdemServico",
                column: "TecnicoResponsavelId",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Funcionario_TecnicoResponsavelId",
                table: "OrdemServico");

            migrationBuilder.DropIndex(
                name: "IX_OrdemServico_TecnicoResponsavelId",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "DataConserto",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "DescricaoServicoPrestado",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "PercentualEstabelecimento",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "PercentualTecnico",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "TecnicoResponsavelId",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "ValorAcrescentado",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "ValorConsertoBase",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "ValorPecas",
                table: "OrdemServico");
        }
    }
}
