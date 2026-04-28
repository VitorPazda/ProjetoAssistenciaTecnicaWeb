using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Services.Exceptions;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class FuncionarioService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public FuncionarioService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public void Insert(FuncionarioService obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public async Task<List<Funcionario>> FindAsync(string nome, string cpf_cnpj, string telefone)
        {
            var resultado = _context.Funcionario
                .Include(f => f.Endereco)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                resultado = resultado.Where(f => f.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(cpf_cnpj))
            {
                resultado = resultado.Where(f => f.CPF_CNPJ.Contains(cpf_cnpj));
            }

            if (!string.IsNullOrEmpty(telefone))
            {
                resultado = resultado.Where(f => f.Telefone.Contains(telefone));
            }
            else
            {
                // Retornar os ultimos 5 funcionarios cadastrados, caso nome e cpf/cnpj n sejam informaods
                return await resultado
                    .OrderByDescending(f => f.DataCadastro)
                    .Take(5)
                    .ToListAsync();
            }
            return await resultado.ToListAsync();
        }

        public void Update(Funcionario obj)
        {
            if (_context.Funcionario.Any(f => f.IdFuncionario == obj.IdFuncionario))
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
