using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Services.Exceptions;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class PecaService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public PecaService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }
        
        /*
        public async Task<Peca> FindAsync(int id)
        {

        }
        */
    }
}
