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
        public StatusOrdemServico Status { get; set; }

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

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Funcionario")]
        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        // Todos os atributos nulos da Ordem de Servico
        [Display(Name = "Data Conserto")]
        [DataType(DataType.Date)]
        public DateTime? DataConserto { get; set; }

        [StringLength(300, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Descrição do Serviço Prestado")]
        [DataType(DataType.Text)]
        public string? DescricaoServicoPrestado { get; set; }

        [Display(Name = "Técnico Responsável")]
        public int? TecnicoResponsavelId { get; set; }
        public Funcionario? TecnicoResponsavel { get; set; }

        [Range(0.0, 10000000.0, ErrorMessage = "{0} o tamanho deve ser entre {1} e {2}")]
        [Display(Name = "Valor do Conserto Base")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? ValorConsertoBase { get; set; }

        [Range(0.0, 100.0, ErrorMessage = "{0} o tamanho deve ser entre {1} e {2}")]
        [Display(Name = "Percentual do Estabelecimento")]
        [DisplayFormat(DataFormatString = "{0:N2}%")]
        public decimal? PercentualEstabelecimento { get; set; }

        [Range(0.0, 100.0, ErrorMessage = "{0} o tamanho deve ser entre {1} e {2}")]
        [Display(Name = "Percentual do Técnico")]
        [DisplayFormat(DataFormatString = "{0:N2}%")]
        public decimal? PercentualTecnico { get; set; }

        [Range(0.0, 10000000.0, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Valor das Peças")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? ValorPecas { get; set; }

        [Range(0.0, 10000000.0, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Valor Acrescentado")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? ValorAcrescentado { get; set; }
        public OrdemServico()
        {
        }

        public OrdemServico(int idOrdemServico, int tick, int numeroAtendimento, string defeito, DateTime dataAbertura, string acessorios, StatusOrdemServico status, int idOrcamentoInicial, Cliente cliente, Produto produto, int funcionarioId)
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
