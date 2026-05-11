using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Orcamento
    {
        [Key]
        public int IdOrcamento { get; set; }

        public string CodigoOrcamento { get; set; }
        
        public double Valor {  get; set; }
        public Orcamento()
        {
        }

        public Orcamento(int idOrcamento, string codigoOrcamento, double valor)
        {
            IdOrcamento = idOrcamento;
            CodigoOrcamento = codigoOrcamento;
            Valor = valor;
        }
    }
}
