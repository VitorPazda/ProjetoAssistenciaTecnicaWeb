using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Services;

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
    }
}
