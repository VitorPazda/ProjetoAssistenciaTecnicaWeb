using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using ProjetoAssistenciaTecnicaWeb.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        private readonly FuncionarioService _funcionarioService;

        public FuncionariosController(ProjetoAssistenciaTecnicaWebContext context, FuncionarioService funcionarioService)
        {
            _context = context;
            _funcionarioService = funcionarioService;
        }

        // GET: Funcionarios
       
        public async Task<IActionResult> Index()
        {
            var projetoAssistenciaTecnicaWebContext = _context.Funcionario.Include(f => f.Endereco);
            return View(await projetoAssistenciaTecnicaWebContext.ToListAsync());
        }

        // GET: Funcioraios/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.IdFuncionario == id);

            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new FuncionarioFormViewModel { Funcionario = funcionario, Endereco = funcionario.Endereco };

            return View(viewModel);
        }
    }
}
