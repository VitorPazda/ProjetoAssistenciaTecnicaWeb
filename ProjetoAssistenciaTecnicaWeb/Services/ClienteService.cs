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

        /*
        public async Task<List<Cliente>> FindAsync (string nome) 
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
        */

        public async Task<List<Cliente>> FindAsync(string nome, string cpf)
        {
            var resultado = _context.Cliente
                .Include(x => x.Endereco)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                resultado = resultado.Where(x => x.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                resultado = resultado.Where(x => x.CPF_CNPJ.Contains(cpf));
            }
            else
            {
                // retornar os utlimos 5 clientes cadastrados, caso nome e cpf nao sejam informados
                return await resultado
                    .OrderByDescending(x => x.DataCadastro)
                    .Take(5)
                    .ToListAsync();
            }

            return await resultado.ToListAsync();
        }

        public void Update(Cliente obj)
        {
            if (_context.Cliente.Any(x => x.IdCliente == obj.IdCliente))
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
