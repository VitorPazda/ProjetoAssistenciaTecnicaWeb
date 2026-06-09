using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Orcamento
    {
        [Key]
        public int IdOrcamento { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Código Orçamento")]
        [DataType(DataType.Text)]
        public int CodigoOrcamento { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(0.0, 10000000.0, ErrorMessage = "{0} o tamanho deve ser entre {2} e 1")]
        [Display(Name = "Valor de Compra")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Valor { get; set; }

        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }
        public Orcamento()
        {
        }

        public Orcamento(int idOrcamento, int codigoOrcamento, double valor, int funcionarioId)
        {
            IdOrcamento = idOrcamento;
            CodigoOrcamento = codigoOrcamento;
            Valor = valor;
            FuncionarioId = funcionarioId;
        }
    }
}
