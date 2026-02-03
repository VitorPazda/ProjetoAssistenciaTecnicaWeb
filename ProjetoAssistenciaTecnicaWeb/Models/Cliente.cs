using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(13, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "CPF")]
        public string CPF_CNPJ {get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(12, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Data Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Modalidade { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente() 
        {
        }

        public Cliente(int idCliente, string nome, string cpf_cnpj, string telefone, string email, DateTime dataNascimento, DateTime dataCadastro, string modalidade, Endereco endereco)
        {
            IdCliente = idCliente;
            Nome = nome;
            CPF_CNPJ = cpf_cnpj;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Modalidade = modalidade;
            Endereco = endereco;
        }
    }
}
