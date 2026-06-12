using ProjetoAssistenciaTecnicaWeb.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public static class OrdemServicoPdfGenerator
    {
        public static byte[] Generate(OrdemServico os)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Content().Column(col =>
                    {
                        col.Item().Text("ORÇAMENTO")
                            .FontSize(20)
                            .Bold();

                        col.Item().Text($"OS: {os.NumeroAtendimento}");

                        col.Item().Text($"Cliente: {os.Cliente?.Nome}");

                        col.Item().Text($"Produto: {os.Produto?.Modelo}");

                        col.Item().Text($"Defeito: {os.Defeito}");

                        col.Item().Text($"Serviço: {os.DescricaoServicoPrestado}");

                        col.Item().Text($"Mão de obra: R$ {os.ValorConsertoBase:N2}");

                        col.Item().Text($"Valor peças: R$ {os.ValorPecas:N2}");

                        col.Item().Text($"Valor adicional: R$ {os.ValorAcrescentado:N2}");

                        col.Item().Text(
                            $"Valor total: R$ {(os.ValorConsertoBase.GetValueOrDefault() + os.ValorPecas.GetValueOrDefault() + os.ValorAcrescentado.GetValueOrDefault()):N2}");

                        col.Item().Text($"Funcionário: {os.Funcionario?.Nome}");

                        col.Item().Text($"Data: {DateTime.Now:dd/MM/yyyy}");
                    });
                });
            }).GeneratePdf();
        }
    }
}