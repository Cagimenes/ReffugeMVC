using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReffugeMVC.Models;

namespace ReffugeMVC.Controllers
{
    public class TipoConteudoController : Controller
    {
        private readonly Contexto _context;

        public TipoConteudoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoConteudo
        public async Task<IActionResult> Index()
        {
              return _context.TipoConteudo != null ? 
                          View(await _context.TipoConteudo.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoConteudo'  is null.");
        }

        // GET: TipoConteudo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoConteudo == null)
            {
                return NotFound();
            }

            var tipoConteudo = await _context.TipoConteudo
                .FirstOrDefaultAsync(m => m.TipoConteudoId == id);
            if (tipoConteudo == null)
            {
                return NotFound();
            }

            return View(tipoConteudo);
        }

        // GET: TipoConteudo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoConteudo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoConteudoId,NomeTipoConteudo")] TipoConteudo tipoConteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoConteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConteudo);
        }

        // GET: TipoConteudo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoConteudo == null)
            {
                return NotFound();
            }

            var tipoConteudo = await _context.TipoConteudo.FindAsync(id);
            if (tipoConteudo == null)
            {
                return NotFound();
            }
            return View(tipoConteudo);
        }

        // POST: TipoConteudo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoConteudoId,NomeTipoConteudo")] TipoConteudo tipoConteudo)
        {
            if (id != tipoConteudo.TipoConteudoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoConteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoConteudoExists(tipoConteudo.TipoConteudoId))
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
            return View(tipoConteudo);
        }

        // GET: TipoConteudo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoConteudo == null)
            {
                return NotFound();
            }

            var tipoConteudo = await _context.TipoConteudo
                .FirstOrDefaultAsync(m => m.TipoConteudoId == id);
            if (tipoConteudo == null)
            {
                return NotFound();
            }

            return View(tipoConteudo);
        }

        // POST: TipoConteudo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoConteudo == null)
            {
                return Problem("Entity set 'Contexto.TipoConteudo'  is null.");
            }
            var tipoConteudo = await _context.TipoConteudo.FindAsync(id);
            if (tipoConteudo != null)
            {
                _context.TipoConteudo.Remove(tipoConteudo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoConteudoExists(int id)
        {
          return (_context.TipoConteudo?.Any(e => e.TipoConteudoId == id)).GetValueOrDefault();
        }
    }
}
