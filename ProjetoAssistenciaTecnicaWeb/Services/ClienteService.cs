using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class ClienteService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public ClienteService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public void Insert(ClienteService obj) 
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public async Task<List<Cliente>> BuscaAsync(string nome) 
        {
            var resultado = _context.Cliente
                .Include(x => x.Endereco)
                .Where(x => x.Nome.Contains(nome));

            return await resultado.ToListAsync();
        }
    }
}
