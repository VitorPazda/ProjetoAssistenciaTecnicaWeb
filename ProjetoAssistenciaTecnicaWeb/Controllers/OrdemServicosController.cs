using Microsoft.AspNetCore.Mvc;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using ProjetoAssistenciaTecnicaWeb.Services;
using System.Diagnostics;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class OrdemServicosController : Controller
    {
        private readonly OrdemServicoService _ordemServicoService;
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;
        private readonly FuncionarioService _funcionarioService;
        public OrdemServicosController(OrdemServicoService ordemServicoService, ProdutoService produtoService, ClienteService clienteService, FuncionarioService funcionarioService)
        {
            _ordemServicoService = ordemServicoService;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
        }

        // GET: OrdemServicos
        public async Task<IActionResult> Index()
        {
            var ordemServico = await _ordemServicoService.FindAllAsync();
            return View(ordemServico);
        }

        // GET: OrdemServicos/Create
        public async Task<IActionResult> Create()
        {
            var clientes = await _clienteService.FindAllAsync();
            var produtos = await _produtoService.FindAllAsync();
            var funcionarios = await _funcionarioService.FindAllAsync();

            var viewModel = new OrdemServicoFormViewModel { OrdemServico = new OrdemServico(), Clientes = clientes, Produtos = produtos, Funcionarios = funcionarios };
            return View(viewModel);
        }

        // POST: OrdemServicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdemServico ordemServico)
        {
            await _ordemServicoService.InsertAsync(ordemServico);
            return RedirectToAction(nameof(Index));
        }

        // GET: OrdemServicos/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var ordemServico = await _ordemServicoService.FindByIdAsync(id.Value);

            if (ordemServico == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(ordemServico);
        }

        // POST: OrdemServicos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ordemServico = await _ordemServicoService.FindByIdAsync(id);

            if (ordemServico != null)
            {
                await _ordemServicoService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: OrdemServicos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var ordemServico = await _ordemServicoService.FindByIdAsync(id.Value);

            if (ordemServico == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new OrdemServicoFormViewModel { OrdemServico = ordemServico };

            return View(viewModel);
        }

        // GET: OrdemServicos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var ordemServico = await _ordemServicoService.FindByIdAsync(id.Value);

            if (ordemServico == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var clientes = await _clienteService.FindAllAsync();
            var produtos = await _produtoService.FindAllAsync();

            var viewModel = new OrdemServicoFormViewModel { OrdemServico = ordemServico, Produtos = produtos, Clientes = clientes };

            return View(viewModel);
        }

        // POST: OrdemServicos/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrdemServicoFormViewModel viewModel)
        {
            if (id != viewModel.OrdemServico.IdOrdemServico)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
            }
            try
            {
                await _ordemServicoService.UpdateAsync(viewModel.OrdemServico);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); ;
            }
        }

        public async Task<IActionResult> Find(int? numeroAtendimento, DateTime? dataAbertura)
        {
            var resultado = await _ordemServicoService.FindAsync(numeroAtendimento, dataAbertura);
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
