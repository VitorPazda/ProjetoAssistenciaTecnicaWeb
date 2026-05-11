using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class OrcamentoService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public OrcamentoService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public async Task<List<Orcamento>> FindAllAsync()
        {
            return await _context.Orcamento.ToListAsync();
        }
    }
}
