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

        // GET: Pecas/
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
    }
}
