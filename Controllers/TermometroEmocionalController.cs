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
    public class TermometroEmocionalController : Controller
    {
        private readonly Contexto _context;

        public TermometroEmocionalController(Contexto context)
        {
            _context = context;
        }

        // GET: TermometroEmocional
        public async Task<IActionResult> Index()
        {
            var contexto = _context.TermometroEmocional.Include(t => t.Cliente).Include(t => t.TipoEmocao);
            return View(await contexto.ToListAsync());
        }

        // GET: TermometroEmocional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TermometroEmocional == null)
            {
                return NotFound();
            }

            var termometroEmocional = await _context.TermometroEmocional
                .Include(t => t.Cliente)
                .Include(t => t.TipoEmocao)
                .FirstOrDefaultAsync(m => m.TermometroEmocionalId == id);
            if (termometroEmocional == null)
            {
                return NotFound();
            }

            return View(termometroEmocional);
        }

        // GET: TermometroEmocional/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            ViewData["TipoEmocaoId"] = new SelectList(_context.TipoEmocao, "TipoEmocaoId", "NomeTipoEmocao");
            return View();
        }

        // POST: TermometroEmocional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermometroEmocionalId,TipoEmocaoId,ClienteId,Data")] TermometroEmocional termometroEmocional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(termometroEmocional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", termometroEmocional.ClienteId);
            ViewData["TipoEmocaoId"] = new SelectList(_context.TipoEmocao, "TipoEmocaoId", "NomeTipoEmocao", termometroEmocional.TipoEmocaoId);
            return View(termometroEmocional);
        }

        // GET: TermometroEmocional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TermometroEmocional == null)
            {
                return NotFound();
            }

            var termometroEmocional = await _context.TermometroEmocional.FindAsync(id);
            if (termometroEmocional == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", termometroEmocional.ClienteId);
            ViewData["TipoEmocaoId"] = new SelectList(_context.TipoEmocao, "TipoEmocaoId", "NomeTipoEmocao", termometroEmocional.TipoEmocaoId);
            return View(termometroEmocional);
        }

        // POST: TermometroEmocional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermometroEmocionalId,TipoEmocaoId,ClienteId,Data")] TermometroEmocional termometroEmocional)
        {
            if (id != termometroEmocional.TermometroEmocionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termometroEmocional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermometroEmocionalExists(termometroEmocional.TermometroEmocionalId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", termometroEmocional.ClienteId);
            ViewData["TipoEmocaoId"] = new SelectList(_context.TipoEmocao, "TipoEmocaoId", "NomeTipoEmocao", termometroEmocional.TipoEmocaoId);
            return View(termometroEmocional);
        }

        // GET: TermometroEmocional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TermometroEmocional == null)
            {
                return NotFound();
            }

            var termometroEmocional = await _context.TermometroEmocional
                .Include(t => t.Cliente)
                .Include(t => t.TipoEmocao)
                .FirstOrDefaultAsync(m => m.TermometroEmocionalId == id);
            if (termometroEmocional == null)
            {
                return NotFound();
            }

            return View(termometroEmocional);
        }

        // POST: TermometroEmocional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TermometroEmocional == null)
            {
                return Problem("Entity set 'Contexto.TermometroEmocional'  is null.");
            }
            var termometroEmocional = await _context.TermometroEmocional.FindAsync(id);
            if (termometroEmocional != null)
            {
                _context.TermometroEmocional.Remove(termometroEmocional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermometroEmocionalExists(int id)
        {
          return (_context.TermometroEmocional?.Any(e => e.TermometroEmocionalId == id)).GetValueOrDefault();
        }
    }
}
