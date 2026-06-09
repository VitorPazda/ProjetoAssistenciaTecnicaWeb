namespace ProjetoAssistenciaTecnicaWeb.Models.ViewModels
{
    public class OrcamentoFormViewModel
    {
        public Orcamento Orcamento { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
