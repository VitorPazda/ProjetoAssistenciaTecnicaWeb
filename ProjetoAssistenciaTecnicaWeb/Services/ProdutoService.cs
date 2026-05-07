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
    }
}
