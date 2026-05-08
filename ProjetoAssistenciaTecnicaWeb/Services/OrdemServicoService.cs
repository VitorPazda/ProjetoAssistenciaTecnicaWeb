using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class OrdemServicoService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public OrdemServicoService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

            
        public async Task<List<OrdemServico>> FindAllAsync()
        {
           return await _context.OrdemServico.Include(o => o.Cliente).Include(o => o.Produto).ToListAsync();
        }

        public async Task InsertAsync(OrdemServico ordemServico)
        {
            ordemServico.DataAbertura = DateTime.Now;
            ordemServico.ClienteId = ordemServico.Cliente.IdCliente;
            ordemServico.ProdutoId = ordemServico.Produto.IdProduto;

            _context.OrdemServico.Add(ordemServico);
            await _context.SaveChangesAsync();
        }
    }
}
