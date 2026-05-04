using Microsoft.AspNetCore.Mvc;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using ProjetoAssistenciaTecnicaWeb.Services;
using System.Diagnostics;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var cliente = await _clienteService.FindAllAsync();
            return View(cliente);
        }

        // GET: Clientes/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ClienteFormViewModel { Cliente = new Cliente(), Endereco = new Endereco() };
            return View(viewModel);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente, Endereco endereco)
        {
            await _clienteService.InsertAsync(cliente, endereco);
            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var cliente = await _clienteService.FindByIdAsync(id.Value);

            if (cliente == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(cliente);
        }

        // POST: Clientes/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteService.FindByIdAsync(id);

            if (cliente != null)
            {
                await _clienteService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var cliente = await _clienteService.FindByIdAsync(id.Value);

            if (cliente == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new ClienteFormViewModel { Cliente = cliente, Endereco = cliente.Endereco };

            return View(viewModel);
        }

        // GET: Clientes/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            // Verificar se IdCliente e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var cliente = await _clienteService.FindByIdAsync(id.Value); 
            
            if (cliente == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new ClienteFormViewModel { Cliente = cliente, Endereco = cliente.Endereco };
            return View(viewModel);
        }

        // POST: Clientes/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteFormViewModel viewModel)
        {
            if (id != viewModel.Cliente.IdCliente)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
            }
            try
            {
                await _clienteService.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); ;
            }
        }

        public async Task<IActionResult> Find(string nome, string cpf, string telefone)
        {
            var resultado = await _clienteService.FindAsync(nome, cpf, telefone);
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
