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
    public class TipoExerciciosController : Controller
    {
        private readonly Contexto _context;

        public TipoExerciciosController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoExercicios
        public async Task<IActionResult> Index()
        {
              return _context.TipoExercicios != null ? 
                          View(await _context.TipoExercicios.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoExercicios'  is null.");
        }

        // GET: TipoExercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoExercicios == null)
            {
                return NotFound();
            }

            var tipoExercicios = await _context.TipoExercicios
                .FirstOrDefaultAsync(m => m.TipoExerciciosId == id);
            if (tipoExercicios == null)
            {
                return NotFound();
            }

            return View(tipoExercicios);
        }

        // GET: TipoExercicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoExercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoExerciciosId,NomeTipoExercicios")] TipoExercicios tipoExercicios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoExercicios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoExercicios);
        }

        // GET: TipoExercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoExercicios == null)
            {
                return NotFound();
            }

            var tipoExercicios = await _context.TipoExercicios.FindAsync(id);
            if (tipoExercicios == null)
            {
                return NotFound();
            }
            return View(tipoExercicios);
        }

        // POST: TipoExercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoExerciciosId,NomeTipoExercicios")] TipoExercicios tipoExercicios)
        {
            if (id != tipoExercicios.TipoExerciciosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoExercicios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExerciciosExists(tipoExercicios.TipoExerciciosId))
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
            return View(tipoExercicios);
        }

        // GET: TipoExercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoExercicios == null)
            {
                return NotFound();
            }

            var tipoExercicios = await _context.TipoExercicios
                .FirstOrDefaultAsync(m => m.TipoExerciciosId == id);
            if (tipoExercicios == null)
            {
                return NotFound();
            }

            return View(tipoExercicios);
        }

        // POST: TipoExercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoExercicios == null)
            {
                return Problem("Entity set 'Contexto.TipoExercicios'  is null.");
            }
            var tipoExercicios = await _context.TipoExercicios.FindAsync(id);
            if (tipoExercicios != null)
            {
                _context.TipoExercicios.Remove(tipoExercicios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExerciciosExists(int id)
        {
          return (_context.TipoExercicios?.Any(e => e.TipoExerciciosId == id)).GetValueOrDefault();
        }
    }
}
