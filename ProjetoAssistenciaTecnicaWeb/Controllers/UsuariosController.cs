using Microsoft.AspNetCore.Mvc;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;
using ProjetoAssistenciaTecnicaWeb.Services;
using System.Diagnostics;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class UsuariosControllers : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly FuncionarioService _funcionarioService;

        public UsuariosControllers(UsuarioService usuarioService, FuncionarioService funcionarioService)
        {
            _usuarioService = usuarioService;
            _funcionarioService = funcionarioService;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuario = await _usuarioService.FindAllAsync();
            return View(usuario);
        }

        // GET: Usuarios/Create
        public async Task<IActionResult> Create()
        {
            var funcionarios = await _funcionarioService.FindAllAsync();
            var viewModel = new UsuarioFormViewModel { Usuario = new Usuario(), Funcionarios = funcionarios };
            return View(viewModel);
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioFormViewModel viewModel)
        {
            await _usuarioService.InsertAsync(viewModel.Usuario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var usuario = await _usuarioService.FindByIdAsync(id.Value);

            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.FindByIdAsync(id);

            if (usuario != null)
            {
                await _usuarioService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var usuario = await _usuarioService.FindByIdAsync(id.Value);

            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new UsuarioFormViewModel { Usuario = usuario };

            return View(viewModel);
        }

        // GET: Usuarios/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            // Verificar se IdCliente e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var usuario = await _usuarioService.FindByIdAsync(id.Value);

            if (usuario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new UsuarioFormViewModel { Usuario = usuario };
            return View(viewModel);
        }

        // POST: Usuarios/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioFormViewModel viewModel)
        {
            if (id != viewModel.Usuario.IdUsuario)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
            }
            try
            {
                await _usuarioService.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); ;
            }
        }

        public async Task<IActionResult> Find(string nome, string cpf, string telefone)
        {
            var resultado = await _usuarioService.FindAsync(nome, cpf, telefone);
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
