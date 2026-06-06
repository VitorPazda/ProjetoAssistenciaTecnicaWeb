using ProjetoAssistenciaTecnicaWeb.Migrations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAssistenciaTecnicaWeb.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Senha { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public Usuario()
        {
        }

        public Usuario(int idUsuario, string cpf, string senha, Funcionario funcionario)
        {
            IdUsuario = idUsuario;
            Cpf = cpf;
            Senha = senha;
            Funcionario = funcionario;
        }
    }
}
