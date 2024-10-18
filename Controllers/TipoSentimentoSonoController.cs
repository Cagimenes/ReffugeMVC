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
    public class TipoSentimentoSonoController : Controller
    {
        private readonly Contexto _context;

        public TipoSentimentoSonoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoSentimentoSono
        public async Task<IActionResult> Index()
        {
              return _context.TipoSentimentoSono != null ? 
                          View(await _context.TipoSentimentoSono.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoSentimentoSono'  is null.");
        }

        // GET: TipoSentimentoSono/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoSentimentoSono == null)
            {
                return NotFound();
            }

            var tipoSentimentoSono = await _context.TipoSentimentoSono
                .FirstOrDefaultAsync(m => m.TipoSentimentoSonoId == id);
            if (tipoSentimentoSono == null)
            {
                return NotFound();
            }

            return View(tipoSentimentoSono);
        }

        // GET: TipoSentimentoSono/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSentimentoSono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoSentimentoSonoId,NomeTipoSentimentoSono")] TipoSentimentoSono tipoSentimentoSono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSentimentoSono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSentimentoSono);
        }

        // GET: TipoSentimentoSono/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoSentimentoSono == null)
            {
                return NotFound();
            }

            var tipoSentimentoSono = await _context.TipoSentimentoSono.FindAsync(id);
            if (tipoSentimentoSono == null)
            {
                return NotFound();
            }
            return View(tipoSentimentoSono);
        }

        // POST: TipoSentimentoSono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoSentimentoSonoId,NomeTipoSentimentoSono")] TipoSentimentoSono tipoSentimentoSono)
        {
            if (id != tipoSentimentoSono.TipoSentimentoSonoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSentimentoSono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSentimentoSonoExists(tipoSentimentoSono.TipoSentimentoSonoId))
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
            return View(tipoSentimentoSono);
        }

        // GET: TipoSentimentoSono/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoSentimentoSono == null)
            {
                return NotFound();
            }

            var tipoSentimentoSono = await _context.TipoSentimentoSono
                .FirstOrDefaultAsync(m => m.TipoSentimentoSonoId == id);
            if (tipoSentimentoSono == null)
            {
                return NotFound();
            }

            return View(tipoSentimentoSono);
        }

        // POST: TipoSentimentoSono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoSentimentoSono == null)
            {
                return Problem("Entity set 'Contexto.TipoSentimentoSono'  is null.");
            }
            var tipoSentimentoSono = await _context.TipoSentimentoSono.FindAsync(id);
            if (tipoSentimentoSono != null)
            {
                _context.TipoSentimentoSono.Remove(tipoSentimentoSono);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSentimentoSonoExists(int id)
        {
          return (_context.TipoSentimentoSono?.Any(e => e.TipoSentimentoSonoId == id)).GetValueOrDefault();
        }
    }
}
