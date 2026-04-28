using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Services.Exceptions;

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

        public async Task<List<Cliente>> FindAsync(string nome, string cpf, string telefone)
        {
            var resultado = _context.Cliente
                .Include(c => c.Endereco)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                resultado = resultado.Where(c => c.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                resultado = resultado.Where(c => c.CPF_CNPJ.Contains(cpf));
            }

            if (!string.IsNullOrEmpty(telefone))
            {
                resultado = resultado.Where(c => c.Telefone.Contains(telefone));
            }
            else
            {
                // retornar os utlimos 5 clientes cadastrados, caso nome e cpf nao sejam informados
                return await resultado
                    .OrderByDescending(c => c.DataCadastro)
                    .Take(5)
                    .ToListAsync();
            }

            return await resultado.ToListAsync();
        }

        public void Update(Cliente obj)
        {
            if (_context.Cliente.Any(c => c.IdCliente == obj.IdCliente))
            {
                throw new DirectoryNotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
