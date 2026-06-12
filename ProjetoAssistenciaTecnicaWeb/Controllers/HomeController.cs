using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using System.Diagnostics;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public HomeController(ILogger<HomeController> logger, ProjetoAssistenciaTecnicaWebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.OSFinalizadas =
                await _context.OrdemServico
                    .CountAsync(o => o.Status == StatusOrdemServico.Finalizado);

            ViewBag.OSEmAnalise =
                await _context.OrdemServico
                    .CountAsync(o => o.Status == StatusOrdemServico.EmAnalise);

            ViewBag.ItensConsertadosMes =
                await _context.OrdemServico
                    .CountAsync(o =>
                        o.Status == StatusOrdemServico.Finalizado &&
                        o.DataConserto.HasValue &&
                        o.DataConserto.Value.Month == DateTime.Now.Month &&
                        o.DataConserto.Value.Year == DateTime.Now.Year);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Funcionarios()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View();
        }

        public IActionResult OrdemServicos()
        {
            return View();
        }

        public IActionResult Pecas()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
