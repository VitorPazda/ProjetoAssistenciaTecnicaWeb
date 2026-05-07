using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NSerie { get; set; }

        public string Condicao { get; set; }

        public Produto()
        {
        }

        public Produto(int idProduto, string marca, string modelo, string nSerie, string condicao)
        {
            IdProduto = idProduto;
            Marca = marca;
            Modelo = modelo;
            NSerie  = nSerie;
            Condicao = condicao;
        }
    }
}
