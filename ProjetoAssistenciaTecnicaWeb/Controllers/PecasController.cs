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
    public class PecasController : Controller
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        private readonly PecaService _pecaService;

        public PecasController(ProjetoAssistenciaTecnicaWebContext context, PecaService pecaService)
        {
            _pecaService = pecaService;
        }

        // GET: Pecas
        public async Task<IActionResult> Index()
        {
            var peca = await _pecaService.FindAllAsync();
            return View(peca);
        }

        // GET: Pecas/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Peca peca)
        {
            await _pecaService.InsertAsync(peca);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pecas/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var cliente = await _pecaService.FindByIdAsync(id.Value);

            if (cliente == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(cliente);
        }

        // POST: Pecas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _pecaService.FindByIdAsync(id);

            if (cliente != null)
            {
                await _pecaService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Pecas/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var peca = await _pecaService.FindByIdAsync(id.Value);

            if (peca == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(peca);
        }

        // GET: Pecas/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            // Verificar se Id e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var peca = await _pecaService.FindByIdAsync(id.Value);

            if (peca == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(peca);
        }

        // POST: Pecas/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Peca peca)
        {
            if (id != peca.IdPeca)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
            }
            try
            {
                await _pecaService.UpdateAsync(peca);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); ;
            }
        }

        public async Task<IActionResult> Find(string descricao)
        {
            var resultado = await _pecaService.FindAsync(descricao);
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
