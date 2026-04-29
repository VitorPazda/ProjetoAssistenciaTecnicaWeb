using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Peca
    {
        [Key]
        public int IdPeca { get; set; }

        public float CustoCompra { get; set; }

        public float ValorRevenda { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public int Codigo { get; set; }

        public Peca()
        {
        }

        public Peca(int idPeca, float custoCompra, float valorRevenda, string descricao, int quantidade, int codigo)
        {
            IdPeca = idPeca;
            CustoCompra = custoCompra;
            ValorRevenda = valorRevenda;
            Descricao = descricao;
            Quantidade = quantidade;
            Codigo = codigo;
        }
    }
}
