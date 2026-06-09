using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class ClienteService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public ClienteService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Cliente.
                Include(c => c.Endereco)
                .Include(c => c.Funcionario)
                .ToListAsync();
        }

        public async Task InsertAsync(Cliente cliente, Endereco endereco)
        {
            //Salva o endereco primeiro
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            cliente.DataCadastro = DateTime.Now;
            cliente.EnderecoId = endereco.IdEndereco;

            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _context.Cliente
                .Include(c => c.Endereco)
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        public async Task<List<Cliente>> FindAsync(string nome, string cpf, string telefone)
        {
            var resultado = _context.Cliente
                .Include(c => c.Endereco)
                .Include(c => c.Funcionario)
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
                var cliente = await FindByIdAsync(id);

                var enderecoId = cliente.EnderecoId;

                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();

                bool enderecoEmUso = await _context.Cliente.AnyAsync(c => c.EnderecoId == enderecoId);

                // Caso o Endereco nao seja de nenhum cliente, ele sera excluido
                if (!enderecoEmUso)
                {
                    var endereco = await _context.Endereco.FindAsync(enderecoId);
                    _context.Endereco.Remove(endereco);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Can not delete", e);
            }
        }

        public async Task UpdateAsync(ClienteFormViewModel obj)
        {
            bool hasAny = await _context.Cliente.AnyAsync(c => c.IdCliente == obj.Cliente.IdCliente);

            if (!hasAny)
            {
                throw new ApplicationException("Id not found");
            }

            try
            {
                _context.Update(obj.Cliente);

                _context.Update(obj.Endereco);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
