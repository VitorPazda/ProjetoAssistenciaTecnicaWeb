using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;

namespace ProjetoAssistenciaTecnicaWeb.Services
{
    public class OrdemServicoService
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public OrdemServicoService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

            
        public async Task<List<OrdemServico>> FindAllAsync()
        {
           return await _context.OrdemServico.Include(ordem => ordem.Cliente).Include(ordem => ordem.Produto).ToListAsync();
        }

        public async Task InsertAsync(OrdemServico ordemServico)
        {
            ordemServico.DataAbertura = DateTime.Now;
            ordemServico.ClienteId = ordemServico.Cliente.IdCliente;
            ordemServico.ProdutoId = ordemServico.Produto.IdProduto;

            _context.OrdemServico.Add(ordemServico);
            await _context.SaveChangesAsync();
        }

        public async Task<OrdemServico> FindByIdAsync(int id)
        {
            return await _context.OrdemServico.Include(ordem => ordem.Cliente).Include(ordem => ordem.Produto).FirstOrDefaultAsync(ordem => ordem.IdOrdemServico == id);
        }

        public async Task<List<OrdemServico>> FindAsync(int? numeroAtendimento, DateTime? dataAbertura)
        {
            var resultado = _context.OrdemServico
                .Include(ordem => ordem.Cliente)
                .Include(ordem => ordem.Produto)
                .AsQueryable();

            if (numeroAtendimento.HasValue)
            {
                resultado = resultado.Where(ordem => ordem.NumeroAtendimento == numeroAtendimento.Value);
            }

            if (dataAbertura.HasValue)
            {
                resultado = resultado.Where(ordem => ordem.DataAbertura.Date == dataAbertura.Value.Date );
            }

            else
            {
                // Retornar as 5 ultimas ordens cadastradas, caso nome numeroAtendimento ou dataAbertura n sejam informadas
                return await resultado
                    .OrderByDescending(ordem => ordem.DataAbertura)
                    .Take(5)
                    .ToListAsync();
            }
            return await resultado.ToListAsync();
        }
    }
}
