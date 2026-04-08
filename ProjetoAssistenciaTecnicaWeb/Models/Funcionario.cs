using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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

        public string CPF_CNPJ { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Modalidade { get; set; }

        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        public string Categoria { get; set; }
        

        public string CodigoFuncionario { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int idFuncionario, string nome, string cPF_CNPJ, string telefone, string email, DateTime dataNascimento, DateTime dataCadastro, string modalidade, int enderecoId, Endereco endereco, string categoria, string codigoFuncionario)
        {
            IdFuncionario = idFuncionario;
            Nome = nome;
            CPF_CNPJ = cPF_CNPJ;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Modalidade = modalidade;
            EnderecoId = enderecoId;
            Endereco = endereco;
            Categoria = categoria;
            CodigoFuncionario = codigoFuncionario;
        }
    }
}
