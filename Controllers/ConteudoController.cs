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
    public class ConteudoController : Controller
    {
        private readonly Contexto _context;

        public ConteudoController(Contexto context)
        {
            _context = context;
        }

        // GET: Conteudo
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Conteudo.Include(c => c.TipoConteudo);
            return View(await contexto.ToListAsync());
        }

        // GET: Conteudo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conteudo == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo
                .Include(c => c.TipoConteudo)
                .FirstOrDefaultAsync(m => m.ConteudoId == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // GET: Conteudo/Create
        public IActionResult Create()
        {
            ViewData["TipoConteudoId"] = new SelectList(_context.TipoConteudo, "TipoConteudoId", "NomeTipoConteudo");
            return View();
        }

        // POST: Conteudo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConteudoId,NomeConteudo,TipoConteudoId")] Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoConteudoId"] = new SelectList(_context.TipoConteudo, "TipoConteudoId", "NomeTipoConteudo", conteudo.TipoConteudoId);
            return View(conteudo);
        }

        // GET: Conteudo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conteudo == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }
            ViewData["TipoConteudoId"] = new SelectList(_context.TipoConteudo, "TipoConteudoId", "NomeTipoConteudo", conteudo.TipoConteudoId);
            return View(conteudo);
        }

        // POST: Conteudo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConteudoId,NomeConteudo,TipoConteudoId")] Conteudo conteudo)
        {
            if (id != conteudo.ConteudoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteudoExists(conteudo.ConteudoId))
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
            ViewData["TipoConteudoId"] = new SelectList(_context.TipoConteudo, "TipoConteudoId", "NomeTipoConteudo", conteudo.TipoConteudoId);
            return View(conteudo);
        }

        // GET: Conteudo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conteudo == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo
                .Include(c => c.TipoConteudo)
                .FirstOrDefaultAsync(m => m.ConteudoId == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // POST: Conteudo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conteudo == null)
            {
                return Problem("Entity set 'Contexto.Conteudo'  is null.");
            }
            var conteudo = await _context.Conteudo.FindAsync(id);
            if (conteudo != null)
            {
                _context.Conteudo.Remove(conteudo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteudoExists(int id)
        {
          return (_context.Conteudo?.Any(e => e.ConteudoId == id)).GetValueOrDefault();
        }
    }
}
