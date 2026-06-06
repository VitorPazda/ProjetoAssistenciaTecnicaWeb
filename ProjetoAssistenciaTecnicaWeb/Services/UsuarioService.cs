using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class UsuarioService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public UsuarioService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuario.Include(f => f.Funcionario).ToListAsync();
        }

        public async Task InsertAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuario.Include(f => f.Funcionario).FirstOrDefaultAsync(u => u.IdUsuario == id);
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

        public async Task RemoveAsync(int id)
        {
            try
            {
                var usuario = await FindByIdAsync(id);

                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Can not delete", e);
            }
        }

        public async Task UpdateAsync(UsuarioFormViewModel obj)
        {
            bool hasAny = await _context.Usuario.AnyAsync(u => u.IdUsuario == obj.Usuario.IdUsuario);

            if (!hasAny)
            {
                throw new ApplicationException("Id not found");
            }

            try
            {
                _context.Update(obj.Usuario);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
