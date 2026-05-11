using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class OrcamentoService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public OrcamentoService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public async Task<List<Orcamento>> FindAllAsync()
        {
            return await _context.Orcamento.ToListAsync();
        }

        public async Task InsertAsync(Orcamento orcamento)
        {
            _context.Orcamento.Add(orcamento);
            await _context.SaveChangesAsync();

            orcamento.CodigoOrcamento = orcamento.IdOrcamento;
            await _context.SaveChangesAsync();
        }

        public async Task<Orcamento> FindByIdAsync(int id)
        {
            return await _context.Orcamento.FirstOrDefaultAsync(orcamento => orcamento.IdOrcamento == id);
        }

        public async Task<List<Orcamento>> FindAsync(int? codigo)
        {
            var resultado = _context.Orcamento.AsQueryable();

            if (codigo.HasValue)
            {
                resultado = resultado.Where(orcamento => orcamento.CodigoOrcamento == codigo.Value);
            }

            return await resultado.ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var orcamento = await FindByIdAsync(id);

                _context.Orcamento.Remove(orcamento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Can not delete", e);
            }
        }

        public async Task UpdateAsync(Orcamento obj)
        {
            bool hasAny = await _context.Orcamento.AnyAsync(orcamento => orcamento.IdOrcamento == obj.IdOrcamento);

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
