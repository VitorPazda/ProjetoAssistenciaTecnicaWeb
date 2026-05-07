using Microsoft.AspNetCore.Mvc;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using ProjetoAssistenciaTecnicaWeb.Services;
using System.Diagnostics;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;

        public ProdutosController(ProdutoService produtoService, ClienteService clienteService)
        {
            _produtoService = produtoService;
            _clienteService = clienteService;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produto = await _produtoService.FindAllAsync();
            return View(produto);
        }

        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            var clientes = await _clienteService.FindAllAsync();

            var viewModel = new ProdutoFormViewModel { Produto = new Produto(), Clientes = clientes };
            return View(viewModel);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            await _produtoService.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var produto = await _produtoService.FindByIdAsync(id.Value);

            if (produto == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(produto);
        }

        // POST: Produtos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoService.FindByIdAsync(id);

            if (produto != null)
            {
                await _produtoService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var produto = await _produtoService.FindByIdAsync(id.Value);

            if (produto == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new ProdutoFormViewModel { Produto = produto };

            return View(viewModel);
        }

        // GET: Produtos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            // Verificar se Id e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var produto = await _produtoService.FindByIdAsync(id.Value);

            if (produto == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var clientes = await _clienteService.FindAllAsync();

            var viewModel = new ProdutoFormViewModel { Produto = produto, Clientes = clientes };

            return View(viewModel);
        }

        // POST: Produtos/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoFormViewModel viewModel)
        {
            if (id != viewModel.Produto.IdProduto)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
            }
            try
            {
                await _produtoService.UpdateAsync(viewModel.Produto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); ;
            }
        }

        public async Task<IActionResult> Find(string modelo)
        {
            var resultado = await _produtoService.FindAsync(modelo);
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
