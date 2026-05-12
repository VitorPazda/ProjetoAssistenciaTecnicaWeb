using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Peca
    {
        [Key]
        public int IdPeca { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(0.0, 10000000.0, ErrorMessage = "{0} o tamanho deve ser entre {2} e 1")]
        [Display(Name = "Valor de Compra")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float ValorCompra { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(0.0, 10000000.0, ErrorMessage = "{0} o tamanho deve ser entre {2} e 1")]
        [Display(Name = "Valor de Revenda")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float ValorRevenda { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} required")]
        [Range(0.0, 10000000.0, ErrorMessage = "{0} o tamanho deve ser entre {2} e 1")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        public int Codigo { get; set; }

        public Peca()
        {
        }

        public Peca(int idPeca, float valorCompra, float valorRevenda, string descricao, int quantidade, int codigo)
        {
            IdPeca = idPeca;
            ValorCompra = valorCompra;
            ValorRevenda = valorRevenda;
            Descricao = descricao;
            Quantidade = quantidade;
            Codigo = codigo;
        }
    }
}
