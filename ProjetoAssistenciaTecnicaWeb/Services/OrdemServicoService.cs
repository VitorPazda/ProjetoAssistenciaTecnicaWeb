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
            return await _context.OrdemServico.Include(o => o.Cliente).ToListAsync();
        }
    }
}
