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
    public class ExerciciosController : Controller
    {
        private readonly Contexto _context;

        public ExerciciosController(Contexto context)
        {
            _context = context;
        }

        // GET: Exercicios
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Exercicios.Include(e => e.TipoExercicios);
            return View(await contexto.ToListAsync());
        }

        // GET: Exercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicios = await _context.Exercicios
                .Include(e => e.TipoExercicios)
                .FirstOrDefaultAsync(m => m.ExerciciosId == id);
            if (exercicios == null)
            {
                return NotFound();
            }

            return View(exercicios);
        }

        // GET: Exercicios/Create
        public IActionResult Create()
        {
            ViewData["TipoExerciciosId"] = new SelectList(_context.TipoExercicios, "TipoExerciciosId", "NomeTipoExercicios");
            return View();
        }

        // POST: Exercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciciosId,NomeExercicios,TipoExerciciosId")] Exercicios exercicios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercicios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoExerciciosId"] = new SelectList(_context.TipoExercicios, "TipoExerciciosId", "NomeTipoExercicios", exercicios.TipoExerciciosId);
            return View(exercicios);
        }

        // GET: Exercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicios = await _context.Exercicios.FindAsync(id);
            if (exercicios == null)
            {
                return NotFound();
            }
            ViewData["TipoExerciciosId"] = new SelectList(_context.TipoExercicios, "TipoExerciciosId", "NomeTipoExercicios", exercicios.TipoExerciciosId);
            return View(exercicios);
        }

        // POST: Exercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciciosId,NomeExercicios,TipoExerciciosId")] Exercicios exercicios)
        {
            if (id != exercicios.ExerciciosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercicios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciciosExists(exercicios.ExerciciosId))
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
            ViewData["TipoExerciciosId"] = new SelectList(_context.TipoExercicios, "TipoExerciciosId", "NomeTipoExercicios", exercicios.TipoExerciciosId);
            return View(exercicios);
        }

        // GET: Exercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicios = await _context.Exercicios
                .Include(e => e.TipoExercicios)
                .FirstOrDefaultAsync(m => m.ExerciciosId == id);
            if (exercicios == null)
            {
                return NotFound();
            }

            return View(exercicios);
        }

        // POST: Exercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exercicios == null)
            {
                return Problem("Entity set 'Contexto.Exercicios'  is null.");
            }
            var exercicios = await _context.Exercicios.FindAsync(id);
            if (exercicios != null)
            {
                _context.Exercicios.Remove(exercicios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciciosExists(int id)
        {
          return (_context.Exercicios?.Any(e => e.ExerciciosId == id)).GetValueOrDefault();
        }
    }
}
