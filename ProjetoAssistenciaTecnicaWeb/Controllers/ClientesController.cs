using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Data;
using ProjetoAssistenciaTecnicaWeb.Models;
using ProjetoAssistenciaTecnicaWeb.Models.ViewModels;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ProjetoAssistenciaTecnicaWebContext _context;

        public ClientesController(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var projetoAssistenciaTecnicaWebContext = _context.Cliente.Include(c => c.Endereco);
            return View(await projetoAssistenciaTecnicaWebContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            var viewModel = new ClienteFormViewModel { Cliente = new Cliente(), Endereco = new Endereco()};
            return View(viewModel);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente, Endereco endereco)
        {
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            cliente.DataCadastro = DateTime.Now;
            cliente.EnderecoId = endereco.IdEndereco;
            _context.Add(cliente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var cliente = await _context.Cliente.Include(c => c.Endereco).FirstOrDefaultAsync(c => c.IdCliente == id);
            if (cliente == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new ClienteFormViewModel { Cliente = cliente, Endereco = cliente.Endereco };
            return View(viewModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteFormViewModel viewModel)
        {
            if (id != viewModel.Cliente.IdCliente)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Update(viewModel.Endereco);
                await _context.SaveChangesAsync();

                viewModel.Cliente.EnderecoId = viewModel.Endereco.IdEndereco;

                _context.Update(viewModel.Cliente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                throw;
            }
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.IdCliente == id);

            if (cliente != null)
            {
                _context.Endereco.Remove(cliente.Endereco);
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.IdCliente == id);
        }

        public async Task UpdateAsync(Cliente cliente) 
        {
            bool temAlgum = await _context.Cliente.AnyAsync(x => x.IdCliente == cliente.IdCliente);
            if (!temAlgum)
            {
                throw new DirectoryNotFoundException("Id nao encontrado");
            }
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }
}
