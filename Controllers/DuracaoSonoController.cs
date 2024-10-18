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
    public class DuracaoSonoController : Controller
    {
        private readonly Contexto _context;

        public DuracaoSonoController(Contexto context)
        {
            _context = context;
        }

        // GET: DuracaoSono
        public async Task<IActionResult> Index()
        {
              return _context.DuracaoSono != null ? 
                          View(await _context.DuracaoSono.ToListAsync()) :
                          Problem("Entity set 'Contexto.DuracaoSono'  is null.");
        }

        // GET: DuracaoSono/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DuracaoSono == null)
            {
                return NotFound();
            }

            var duracaoSono = await _context.DuracaoSono
                .FirstOrDefaultAsync(m => m.DuracaoSonoId == id);
            if (duracaoSono == null)
            {
                return NotFound();
            }

            return View(duracaoSono);
        }

        // GET: DuracaoSono/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuracaoSono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DuracaoSonoId,NomeDuracaoSono")] DuracaoSono duracaoSono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duracaoSono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duracaoSono);
        }

        // GET: DuracaoSono/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DuracaoSono == null)
            {
                return NotFound();
            }

            var duracaoSono = await _context.DuracaoSono.FindAsync(id);
            if (duracaoSono == null)
            {
                return NotFound();
            }
            return View(duracaoSono);
        }

        // POST: DuracaoSono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DuracaoSonoId,NomeDuracaoSono")] DuracaoSono duracaoSono)
        {
            if (id != duracaoSono.DuracaoSonoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duracaoSono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuracaoSonoExists(duracaoSono.DuracaoSonoId))
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
            return View(duracaoSono);
        }

        // GET: DuracaoSono/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DuracaoSono == null)
            {
                return NotFound();
            }

            var duracaoSono = await _context.DuracaoSono
                .FirstOrDefaultAsync(m => m.DuracaoSonoId == id);
            if (duracaoSono == null)
            {
                return NotFound();
            }

            return View(duracaoSono);
        }

        // POST: DuracaoSono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DuracaoSono == null)
            {
                return Problem("Entity set 'Contexto.DuracaoSono'  is null.");
            }
            var duracaoSono = await _context.DuracaoSono.FindAsync(id);
            if (duracaoSono != null)
            {
                _context.DuracaoSono.Remove(duracaoSono);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuracaoSonoExists(int id)
        {
          return (_context.DuracaoSono?.Any(e => e.DuracaoSonoId == id)).GetValueOrDefault();
        }
    }
}
