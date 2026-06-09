using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class FuncionarioService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public FuncionarioService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> FindAllAsync()
        {
            return await _context.Funcionario.Include(f => f.Endereco).ToListAsync();
        }

        public async Task InsertAsync(Funcionario funcionario, Endereco endereco)
        {
            //Salva o endereco primeiro
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            funcionario.DataCadastro = DateTime.Now;
            funcionario.EnderecoId = endereco.IdEndereco;

            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();

            funcionario.CodigoFuncionario = funcionario.IdFuncionario;
            _context.Funcionario.Update(funcionario);

            funcionario.Ativo = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Funcionario> FindByIdAsync(int id)
        {
            return await _context.Funcionario.Include(f => f.Endereco).FirstOrDefaultAsync(f => f.IdFuncionario == id);
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
                    .Where(f => f.Ativo)
                    .OrderByDescending(f => f.DataCadastro)
                    .Take(5)
                    .ToListAsync();
            }
            return await resultado.ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var funcionario = await FindByIdAsync(id);
                var enderecoId = funcionario.EnderecoId;

                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();

                bool enderecoEmUso = await _context.Funcionario.AnyAsync(f => f.EnderecoId == enderecoId);

                // Caso o endereco nao seja de nenhum funcionario, ele sera excluido
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

        public async Task UpdateAsync(FuncionarioFormViewModel obj)
        {
            bool hasAny = await _context.Funcionario.AnyAsync(c => c.IdFuncionario == obj.Funcionario.IdFuncionario);

            if (!hasAny)
            {
                throw new ApplicationException("Id not found");
            }

            try
            {
                _context.Update(obj.Funcionario);

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
