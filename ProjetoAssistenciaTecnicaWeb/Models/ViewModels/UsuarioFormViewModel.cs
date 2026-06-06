namespace ProjetoAssistenciaTecnicaWeb.Models.ViewModels
{
    public class UsuarioFormViewModel
    {
        public Usuario Usuario { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}
