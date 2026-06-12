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
           return await _context.OrdemServico
                .Include(ordem => ordem.Cliente)
                .Include(ordem => ordem.Produto)
                .Include(ordem => ordem.Funcionario)
                .ToListAsync();
        }

        public async Task InsertAsync(OrdemServico ordemServico)
        {
            ordemServico.DataAbertura = DateTime.Now;
            ordemServico.Status = StatusOrdemServico.EmAnalise;

            _context.OrdemServico.Add(ordemServico);
            await _context.SaveChangesAsync();

            var equipamentoExistente = await _context.OrdemServico
                .Where(o =>
                    o.ClienteId == ordemServico.ClienteId &&
                    o.ProdutoId == ordemServico.ProdutoId &&
                    o.IdOrdemServico != ordemServico.IdOrdemServico)
                .OrderBy(o => o.IdOrdemServico)
                .FirstOrDefaultAsync();

            if (equipamentoExistente != null)
            {
                ordemServico.Tick = equipamentoExistente.Tick;
            }
            else
            {
                ordemServico.Tick = ordemServico.IdOrdemServico;
            }

            ordemServico.NumeroAtendimento = ordemServico.IdOrdemServico;
            ordemServico.IdOrcamentoInicial = ordemServico.IdOrdemServico;

            _context.OrdemServico.Update(ordemServico);
            await _context.SaveChangesAsync();
        }

        public async Task<OrdemServico> FindByIdAsync(int id)
        {
            return await _context.OrdemServico
                .Include(ordem => ordem.Cliente)
                .Include(ordem => ordem.Produto)
                .Include(ordem => ordem.Funcionario)
                .FirstOrDefaultAsync(ordem => ordem.IdOrdemServico == id);
        }

        public async Task<List<OrdemServico>> FindAsync(int? numeroAtendimento, DateTime? dataAbertura)
        {
            var resultado = _context.OrdemServico
                .Include(ordem => ordem.Cliente)
                .Include(ordem => ordem.Produto)
                .Include(ordem => ordem.Funcionario)
                .AsQueryable();

            if (numeroAtendimento.HasValue)
            {
                resultado = resultado.Where(ordem => ordem.NumeroAtendimento == numeroAtendimento.Value);
            }

            if (dataAbertura.HasValue)
            {
                resultado = resultado.Where(ordem => ordem.DataAbertura.Date == dataAbertura.Value.Date);
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

        public async Task RemoveAsync(int id)
        {
            try
            {
                var ordemServico = await FindByIdAsync(id);

                _context.OrdemServico.Remove(ordemServico);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Can not delete", e);
            }
        }

        public async Task UpdateAsync(OrdemServico obj)
        {
            bool hasAny = await _context.OrdemServico.AnyAsync(ordem => ordem.IdOrdemServico == obj.IdOrdemServico);

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

        public async Task FinishAsync(int id, OrdemServico dadosFinalizacao)
        {
            var ordemServico = await _context.OrdemServico.FirstOrDefaultAsync(o => o.IdOrdemServico == id);

            if (ordemServico == null)
            {
                throw new ApplicationException("Ordem de serviço não encontrada.");
            }

            ordemServico.DataConserto = dadosFinalizacao.DataConserto;
            ordemServico.DescricaoServicoPrestado = dadosFinalizacao.DescricaoServicoPrestado;

            ordemServico.TecnicoResponsavelId = dadosFinalizacao.TecnicoResponsavelId;

            ordemServico.ValorConsertoBase = dadosFinalizacao.ValorConsertoBase;
            ordemServico.PercentualEstabelecimento = dadosFinalizacao.PercentualEstabelecimento;
            ordemServico.PercentualTecnico = dadosFinalizacao.PercentualTecnico;

            ordemServico.ValorPecas = dadosFinalizacao.ValorPecas;
            ordemServico.ValorAcrescentado = dadosFinalizacao.ValorAcrescentado;

            ordemServico.Status = StatusOrdemServico.Finalizado;

            await _context.SaveChangesAsync();
        }

        public async Task<ReportFormViewModel> GenerateReportAsync()
        {
            return new ReportFormViewModel
            {
                OSAbertas = await _context.OrdemServico.CountAsync(),

                OSFinalizadas = await _context.OrdemServico
                    .CountAsync(o => o.Status == StatusOrdemServico.Finalizado),

                OSEmAnalise = await _context.OrdemServico
                    .CountAsync(o => o.Status == StatusOrdemServico.EmAnalise),

                OSAguardandoCliente = await _context.OrdemServico
                    .CountAsync(o => o.Status == StatusOrdemServico.AguardandoClienteRetirar)
            };
        }
    }
}
