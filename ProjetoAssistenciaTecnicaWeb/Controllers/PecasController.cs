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
            _context = context;
            _pecaService = pecaService;
        }

        // GET: Pecas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peca.ToListAsync());
        }

        // GET: Pecas/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var peca = await _context.Peca
                .FirstOrDefaultAsync(p => p.IdPeca == id);

            if (peca == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(peca);
        }

        // GET: Pecas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Peca peca)
        {
            _context.Add(peca);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Pecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Verificar se IdCliente e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var peca = await _context.Peca.FirstOrDefaultAsync(p => p.IdPeca == id);

            if (peca == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View();
        }

        // POST: Clientes/Edit/5
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
                _context.Update(peca);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); ;
            }
        }

        // GET: Pecas/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var peca = await _context.Peca
                .FirstOrDefaultAsync(p => p.IdPeca == id);

            if (peca == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(peca);
        }

        // POST: Pecas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peca = await _context.Peca
                .FirstOrDefaultAsync(p => p.IdPeca == id);

            if (peca != null)
            {
                _context.Peca.Remove(peca);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task UpdateAsync(Peca peca)
        {
            bool temAlgum = await _context.Peca.AnyAsync(p => p.IdPeca == peca.IdPeca);
            if (!temAlgum)
            {
                throw new DirectoryNotFoundException("Id not found");
            }
            try
            {
                _context.Update(peca);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
        /*
        public async Task<IActionResult> Find(string descricao)
        {
            var resultado = await _pecaService.FindAsync(descricao);
            return View(resultado);
        }
        */
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
