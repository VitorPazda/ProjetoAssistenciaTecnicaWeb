using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class OrdemServico
    {
        [Key]
        public int IdOrdemServico { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Tick")]
        public int Tick { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Número do Atendimento")]
        [DataType(DataType.Text)]
        public int NumeroAtendimento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(300, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.Text)]
        public string Defeito { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Data Abertura")]
        [DataType(DataType.Date)]
        public DateTime DataAbertura { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(300, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Acessórios")]
        [DataType(DataType.Text)]
        public string Acessorios { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        [Display(Name = "ID Orçamento Inicial")]
        public int IdOrcamentoInicial { get; set; }

        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        // Todos os atributos nulos da Ordem de Servico

        public DateTime? DataConserto { get; set; }
        public string? DescricaoServicoPrestado { get; set; }
        public int? TecnicoResponsavelId { get; set; }
        public Funcionario? TecnicoResponsavel { get; set; }
        public decimal? ValorConsertoBase { get; set; }
        public decimal? PercentualEstabelecimento { get; set; }
        public decimal? PercentualTecnico { get; set; }
        public decimal? ValorPecas { get; set; }
        public decimal? ValorAcrescentado { get; set; }
        public OrdemServico()
        {
        }

        public OrdemServico(int idOrdemServico, int tick, int numeroAtendimento, string defeito, DateTime dataAbertura, string acessorios, string status, int idOrcamentoInicial, Cliente cliente, Produto produto, int funcionarioId)
        {
            IdOrdemServico = idOrdemServico;
            Tick = tick;
            NumeroAtendimento = numeroAtendimento;
            Defeito = defeito;
            DataAbertura = dataAbertura;
            Acessorios = acessorios;
            Status = status;
            IdOrcamentoInicial = idOrcamentoInicial;
            Cliente = cliente;
            Produto = produto;
            FuncionarioId = funcionarioId;
        }
    }
}
