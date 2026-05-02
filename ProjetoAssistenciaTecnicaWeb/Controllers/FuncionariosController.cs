using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using ProjetoAssistenciaTecnicaWeb.Services;
using System.Diagnostics;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class FuncionariosController : Controller
    {

        private readonly FuncionarioService _funcionarioService;

        public FuncionariosController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var funcionario = await _funcionarioService.FindAllAsync();
            return View(funcionario);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            var viewModel = new FuncionarioFormViewModel { Funcionario = new Funcionario(), Endereco = new Endereco() };
            return View(viewModel);
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario, Endereco endereco)
        {
            await _funcionarioService.InsertAsync(funcionario, endereco);
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var funcionario = await _funcionarioService.FindByIdAsync(id.Value);

            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var funcionario = await _funcionarioService.FindByIdAsync(id);

            if (funcionario != null)
            {
                await _funcionarioService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var funcionario = await _funcionarioService.FindByIdAsync(id.Value);

            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new FuncionarioFormViewModel { Funcionario = funcionario, Endereco = funcionario.Endereco };

            return View(viewModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Verifica se IdFuncionario e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var funcionario = await _funcionarioService.FindByIdAsync(id.Value);
            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new FuncionarioFormViewModel { Funcionario = funcionario, Endereco = funcionario.Endereco };
            return View(viewModel);
        }

        // POST: Funcionarios/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FuncionarioFormViewModel viewModel)
        {
            if (id != viewModel.Funcionario.IdFuncionario)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
            }
            try
            {
                await _funcionarioService.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Find(string nome, string cpf_cnpj, string telefone)
        {
            var resultado = await _funcionarioService.FindAsync(nome, cpf_cnpj, telefone);
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
