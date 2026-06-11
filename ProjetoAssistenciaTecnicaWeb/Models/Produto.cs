using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.Text)]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.Text)]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.Text)]
        public string NSerie { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.Text)]
        public string Condicao { get; set; } = string.Empty;

        public Cliente Cliente { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; } = 0;

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Funcionario")]
        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }
        public Produto()
        {
        }

        public Produto(int idProduto, string marca, string modelo, string nSerie, string condicao, Cliente cliente, int funcionarioId)
        {
            IdProduto = idProduto;
            Marca = marca;
            Modelo = modelo;
            NSerie  = nSerie;
            Condicao = condicao;
            Cliente = cliente;
            FuncionarioId = funcionarioId;
        }
    }
}
