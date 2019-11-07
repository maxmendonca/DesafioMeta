using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaWebApi.Models;
using MinhaWebApi.Services;
using MinhaWebApi.Models.ViewModels;
using System.Diagnostics;

namespace MinhaWebApi.Controllers
{
    public class ContatoController : Controller
    {
        private readonly MinhaWebApiContext _context;
        private readonly ContatoService _contatoService;
        private readonly TipoContatoService _tipoContatoService;

        public ContatoController(MinhaWebApiContext context, ContatoService contatoService, TipoContatoService tipoContatoService)
        {
            _contatoService = contatoService;
            _tipoContatoService = tipoContatoService;
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
            var list = await _contatoService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _contatoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        // GET: Contatos/Create
        public async Task<IActionResult> Create()
        {
            var tipoContato = await _tipoContatoService.FindAllAsync();
            var viewModel = new ContatoViewModel { TipoContato = tipoContato };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contato contato)
        {
            _contatoService.Insert(contato);
            return RedirectToAction(nameof(Index));
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _contatoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<TipoContato> departments = await _tipoContatoService.FindAllAsync();
            ContatoViewModel viewModel = new ContatoViewModel { Contato = obj, TipoContato = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Contato contato)
        {
            if (id != contato.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(contato);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(contato.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _contatoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _context.Contato.FindAsync(id);
            _context.Contato.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return _context.Contato.Any(e => e.Id == id);
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
