namespace ProjetoAssistenciaTecnicaWeb.Models.ViewModels
{
    public class PecaFormViewModel
    {
        public Peca Peca { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
