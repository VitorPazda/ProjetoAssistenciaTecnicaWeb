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
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            funcionario.DataCadastro = DateTime.Now;
            funcionario.EnderecoId = endereco.IdEndereco;
            _context.Add(funcionario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Verificar se IdCliente e nulo
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var funcionario = await _context.Funcionario.Include(f => f.Endereco).FirstOrDefaultAsync(f => f.IdFuncionario == id);
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
                // Atualizar o endereco, pra depois atualizar o cliente
                _context.Update(viewModel.Endereco);
                await _context.SaveChangesAsync();

                viewModel.Funcionario.EnderecoId = viewModel.Endereco.IdEndereco;

                _context.Update(viewModel.Funcionario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Funcionarios/Delete
        public async Task<IActionResult> Delete(int? id)
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

            return View(funcionario);
        }

        // POST: Funcionarios/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.IdFuncionario == id);

            if (funcionario != null)
            {
                _context.Endereco.Remove(funcionario.Endereco);
                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task UpdateAsync(Funcionario funcionario)
        {
            bool temAlgum = await _context.Funcionario.AnyAsync(f => f.IdFuncionario == funcionario.IdFuncionario);
            if (!temAlgum)
            {
                throw new DirectoryNotFoundException("Id not found");
            }
            try
            {
                _context.Update(funcionario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task<IActionResult> Find(string nome, string cpf_cnpj)
        {
            var resultado = await _funcionarioService.FindAsync(nome, cpf_cnpj);
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
