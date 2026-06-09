namespace ProjetoAssistenciaTecnicaWeb.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente Cliente { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
