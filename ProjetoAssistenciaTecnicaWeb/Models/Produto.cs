using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        public int IdCliente { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NSerie { get; set; }

        public string Tipo { get; set; }
        
        public string Condicao { get; set; }

        public Produto()
        {
        }

        public Produto(int idProduto, int idCliente, string marca, string modelo, string nSerie, string tipo, string condicao)
        {
            IdProduto = idProduto;
            IdCliente = idCliente;
            Marca = marca;
            Modelo = modelo;
            NSerie = nSerie;
            Tipo = tipo;
            Condicao = condicao;
        }
    }
}
