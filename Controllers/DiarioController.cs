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
    public class DiarioController : Controller
    {
        private readonly Contexto _context;

        public DiarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Diario
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Diario.Include(d => d.Cliente);
            return View(await contexto.ToListAsync());
        }

        // GET: Diario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diario == null)
            {
                return NotFound();
            }

            var diario = await _context.Diario
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.DiarioId == id);
            if (diario == null)
            {
                return NotFound();
            }

            return View(diario);
        }

        // GET: Diario/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            return View();
        }

        // POST: Diario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiarioId,DataHorario,ConteudoDiario,ClienteId")] Diario diario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", diario.ClienteId);
            return View(diario);
        }

        // GET: Diario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diario == null)
            {
                return NotFound();
            }

            var diario = await _context.Diario.FindAsync(id);
            if (diario == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", diario.ClienteId);
            return View(diario);
        }

        // POST: Diario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiarioId,DataHorario,ConteudoDiario,ClienteId")] Diario diario)
        {
            if (id != diario.DiarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiarioExists(diario.DiarioId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", diario.ClienteId);
            return View(diario);
        }

        // GET: Diario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diario == null)
            {
                return NotFound();
            }

            var diario = await _context.Diario
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.DiarioId == id);
            if (diario == null)
            {
                return NotFound();
            }

            return View(diario);
        }

        // POST: Diario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diario == null)
            {
                return Problem("Entity set 'Contexto.Diario'  is null.");
            }
            var diario = await _context.Diario.FindAsync(id);
            if (diario != null)
            {
                _context.Diario.Remove(diario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiarioExists(int id)
        {
          return (_context.Diario?.Any(e => e.DiarioId == id)).GetValueOrDefault();
        }
    }
}
