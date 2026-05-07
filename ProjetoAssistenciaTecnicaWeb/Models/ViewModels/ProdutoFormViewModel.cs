namespace ProjetoAssistenciaTecnicaWeb.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
