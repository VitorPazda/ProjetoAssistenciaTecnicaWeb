using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} o tamanho deve ser etre {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "CPF/CNPJ")]
        public string CPF_CNPJ { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(12, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

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
        [StringLength(100, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Modalidade")]
        public string Modalidade { get; set; }

        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(100, ErrorMessage = "{0} o tamanho deve ser entre {2} e {1}")]
        [Display(Name = "Código Funcionario")]
        public string CodigoFuncionario { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int idFuncionario, string nome, string cPF_CNPJ, string telefone, string email, DateTime dataNascimento, DateTime dataCadastro, string modalidade, Endereco endereco, string categoria, string codigoFuncionario)
        {
            IdFuncionario = idFuncionario;
            Nome = nome;
            CPF_CNPJ = cPF_CNPJ;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Modalidade = modalidade;
            Endereco = endereco;
            Categoria = categoria;
            CodigoFuncionario = codigoFuncionario;
        }
    }
}
