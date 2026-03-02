using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class EnderecoService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public EnderecoService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public void Insert(EnderecoService obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
