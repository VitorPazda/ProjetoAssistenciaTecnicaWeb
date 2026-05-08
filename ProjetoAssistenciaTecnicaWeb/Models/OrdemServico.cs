using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class OrdemServico
    {
        [Key]
        public int IdOrdemServico { get; set; }
        public int Tick { get; set; }
        public int NumeroAtendimento { get; set; }
        public string Defeito { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Acessorios { get; set; }
        public string Status { get; set; }
        public int IdOrcamentoInicial { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        public OrdemServico()
        {
        }

        public OrdemServico(int tick, int numeroAtendimento, string defeito, DateTime dataAbertura, string acessorios, string status, int idOrcamentoInicial, Cliente cliente, Produto produto)
        {
            Tick = tick;
            NumeroAtendimento = numeroAtendimento;
            Defeito = defeito;
            DataAbertura = dataAbertura;
            Acessorios = acessorios;
            Status = status;
            IdOrcamentoInicial = idOrcamentoInicial;
            Cliente = cliente;
            Produto = produto;
        }
    }
}
