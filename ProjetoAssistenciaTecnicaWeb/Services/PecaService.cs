using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class PecaService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public PecaService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public async Task<List<Peca>> FindAllAsync()
        {
            return await _context.Peca.ToListAsync();
        }

        public async Task InsertAsync(Peca peca)
        {
            _context.Peca.Add(peca);
            await _context.SaveChangesAsync();

            peca.Codigo = peca.IdPeca;
            await _context.SaveChangesAsync();
        }

        public async Task<Peca> FindByIdAsync(int id)
        {
            return await _context.Peca.FirstOrDefaultAsync(p => p.IdPeca == id);
        }

        public async Task<List<Peca>> FindAsync(string descricao)
        {
            var resultado = _context.Peca
                .Include(p => p.Funcionario)
                .AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
            {
                resultado = resultado.Include(p => p.Funcionario).Where(p => p.Descricao.Contains(descricao));
            }

            return await resultado.ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var peca = await FindByIdAsync(id);

                _context.Peca.Remove(peca);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Can not delete", e);
            }
        }

        public async Task UpdateAsync(Peca obj)
        {
            bool hasAny = await _context.Peca.AnyAsync(p => p.IdPeca == obj.IdPeca);

            if (!hasAny)
            {
                throw new ApplicationException("Id not found");            
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
