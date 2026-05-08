namespace ProjetoAssistenciaTecnicaWeb.Models.ViewModels
{
    public class OrdemServicoFormViewModel
    {
        public OrdemServico OrdemServico { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
