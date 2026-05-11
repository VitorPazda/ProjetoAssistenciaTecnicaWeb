using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using ProjetoAssistenciaTecnicaWeb.Services;
using System.Data;
using System.Diagnostics;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class OrcamentosController : Controller
    {
        private readonly OrcamentoService _orcamentoService;

        public OrcamentosController(ProjetoAssistenciaTecnicaWebContext context, OrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        // GET: Orcamentos
        public async Task<IActionResult> Index()
        {
            var orcamento = await _orcamentoService.FindAllAsync();
            return View(orcamento);
        }

        // GET: Orcamentos/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Orcamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Orcamento orcamento)
        {
            await _orcamentoService.InsertAsync(orcamento);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pecas/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var orcamento = await _orcamentoService.FindByIdAsync(id.Value);

            if (orcamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(orcamento);
        }

        // POST: Orcamentos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var orcamento = await _orcamentoService.FindByIdAsync(id);

            if (orcamento != null)
            {
                await _orcamentoService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Orcamentos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var orcamento = await _orcamentoService.FindByIdAsync(id.Value);

            if (orcamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(orcamento);
        }

        // GET: Orcamentos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            // Verificar se Id e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var orcamento = await _orcamentoService.FindByIdAsync(id.Value);

            if (orcamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(orcamento);
        }

        // POST: Orcamentos/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Orcamento orcamento)
        {
            if (id != orcamento.IdOrcamento)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
            }
            try
            {
                await _orcamentoService.UpdateAsync(orcamento);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); ;
            }
        }

        public async Task<IActionResult> Find(int? codigo)
        {
            var resultado = await _orcamentoService.FindAsync(codigo);
            return View(resultado);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
