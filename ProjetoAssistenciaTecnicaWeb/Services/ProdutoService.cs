using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class ProdutoService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public ProdutoService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.Include(p => p.Cliente).ToListAsync();
        }

        public async Task InsertAsync(Produto produto)
        {
            //Salva o endereco primeiro
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produto.Include(p => p.Cliente).FirstOrDefaultAsync(p => p.IdProduto == id);
        }

        public async Task<List<Produto>> FindAsync(string modelo)
        {
            var resultado = _context.Produto
                .Include(p => p.Cliente)
                .AsQueryable();

            if (!string.IsNullOrEmpty(modelo))
            {
                resultado = resultado.Where(p => p.Modelo.Contains(modelo));
            }

            return await resultado.ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var produto = await FindByIdAsync(id);

                _context.Produto.Remove(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Can not delete", e);
            }
        }

        public async Task UpdateAsync(Produto obj)
        {
            bool hasAny = await _context.Produto.AnyAsync(p => p.IdProduto == obj.IdProduto);

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
