using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF_CNPJ {get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
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
