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

        public async Task<List<Cliente>> FindAsync(string nome)
        {
            var resultado = _context.Cliente
                .Include(x => x.Endereco)
                .AsQueryable();


            if (string.IsNullOrWhiteSpace(nome))
            {
                // retornar os utlimos 5 clientes cadastrados

                return await resultado
                    .OrderByDescending(x => x.DataCadastro)
                    .Take(5)
                    .ToListAsync();
            }

            return await resultado
                .Where(x => x.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}
