namespace ProjetoAssistenciaTecnicaWeb.Models.ViewModels
{
    public class OrdemServicoFormViewModel
    {
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
