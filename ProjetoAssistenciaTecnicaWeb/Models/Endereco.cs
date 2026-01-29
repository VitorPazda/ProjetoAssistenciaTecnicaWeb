using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; } = 0;
        public string Estado { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string NCasa { get; set; } = string.Empty;
        public int IdCliente { get; set; } = 0;

        public Endereco()
        { 
        }

        public Endereco(int idEndereco, string estado, string municipio, string cep, string rua, string bairro, string complemento, string nCasa, int idCliente)
        {
            IdEndereco = idEndereco;
            Estado = estado;
            Municipio = municipio;
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Complemento = complemento;
            NCasa = nCasa;
            IdCliente = idCliente;
        }
    }
}
