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
    public class PlanosController : Controller
    {
        private readonly Contexto _context;

        public PlanosController(Contexto context)
        {
            _context = context;
        }

        // GET: Planos
        public async Task<IActionResult> Index()
        {
              return _context.Planos != null ? 
                          View(await _context.Planos.ToListAsync()) :
                          Problem("Entity set 'Contexto.Planos'  is null.");
        }

        // GET: Planos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Planos == null)
            {
                return NotFound();
            }

            var planos = await _context.Planos
                .FirstOrDefaultAsync(m => m.PlanosId == id);
            if (planos == null)
            {
                return NotFound();
            }

            return View(planos);
        }

        // GET: Planos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanosId,NomePlanos,PrecoPlanos,DescricaoPlanos,DuracaoPlanos")] Planos planos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planos);
        }

        // GET: Planos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Planos == null)
            {
                return NotFound();
            }

            var planos = await _context.Planos.FindAsync(id);
            if (planos == null)
            {
                return NotFound();
            }
            return View(planos);
        }

        // POST: Planos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanosId,NomePlanos,PrecoPlanos,DescricaoPlanos,DuracaoPlanos")] Planos planos)
        {
            if (id != planos.PlanosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanosExists(planos.PlanosId))
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
            return View(planos);
        }

        // GET: Planos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Planos == null)
            {
                return NotFound();
            }

            var planos = await _context.Planos
                .FirstOrDefaultAsync(m => m.PlanosId == id);
            if (planos == null)
            {
                return NotFound();
            }

            return View(planos);
        }

        // POST: Planos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Planos == null)
            {
                return Problem("Entity set 'Contexto.Planos'  is null.");
            }
            var planos = await _context.Planos.FindAsync(id);
            if (planos != null)
            {
                _context.Planos.Remove(planos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanosExists(int id)
        {
          return (_context.Planos?.Any(e => e.PlanosId == id)).GetValueOrDefault();
        }
    }
}
