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
            var projetoAssistenciaTecnicaWebContext = _context;
            return View(await projetoAssistenciaTecnicaWebContext.ToListAsync());
        }
    }
}
