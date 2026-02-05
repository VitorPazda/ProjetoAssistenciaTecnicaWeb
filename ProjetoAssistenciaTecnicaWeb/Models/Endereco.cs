using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; } = 0;

        [Required]
        public string Estado { get; set; } = string.Empty;

        [Required]
        public string Municipio { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CEP")]
        public string Cep { get; set; } = string.Empty;

        [Required]
        public string Rua { get; set; } = string.Empty;

        [Required]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        public string Complemento { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Número da Casa")]
        public string NCasa { get; set; } = string.Empty;

        public Endereco()
        { 
        }

        public Endereco(int idEndereco, string estado, string municipio, string cep, string rua, string bairro, string complemento, string nCasa)
        {
            IdEndereco = idEndereco;
            Estado = estado;
            Municipio = municipio;
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Complemento = complemento;
            NCasa = nCasa;
        }
    }
}
