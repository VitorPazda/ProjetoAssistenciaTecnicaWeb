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

            var viewModel = new PecaFormViewModel { Peca = peca };

            return View(viewModel);
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
