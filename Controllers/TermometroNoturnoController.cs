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
    public class TermometroNoturnoController : Controller
    {
        private readonly Contexto _context;

        public TermometroNoturnoController(Contexto context)
        {
            _context = context;
        }

        // GET: TermometroNoturno
        public async Task<IActionResult> Index()
        {
            var contexto = _context.TermometroNoturno.Include(t => t.Cliente).Include(t => t.DuracaoSono).Include(t => t.TipoSentimentoSono);
            return View(await contexto.ToListAsync());
        }

        // GET: TermometroNoturno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TermometroNoturno == null)
            {
                return NotFound();
            }

            var termometroNoturno = await _context.TermometroNoturno
                .Include(t => t.Cliente)
                .Include(t => t.DuracaoSono)
                .Include(t => t.TipoSentimentoSono)
                .FirstOrDefaultAsync(m => m.TermometroNoturnoId == id);
            if (termometroNoturno == null)
            {
                return NotFound();
            }

            return View(termometroNoturno);
        }

        // GET: TermometroNoturno/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            ViewData["DuracaoSonoId"] = new SelectList(_context.DuracaoSono, "DuracaoSonoId", "NomeDuracaoSono");
            ViewData["TipoSentimentoSonoId"] = new SelectList(_context.TipoSentimentoSono, "TipoSentimentoSonoId", "NomeTipoSentimentoSono");
            return View();
        }

        // POST: TermometroNoturno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermometroNoturnoId,Data,DuracaoSonoId,VezesAcordou,TipoSentimentoSonoId,ClienteId")] TermometroNoturno termometroNoturno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(termometroNoturno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", termometroNoturno.ClienteId);
            ViewData["DuracaoSonoId"] = new SelectList(_context.DuracaoSono, "DuracaoSonoId", "NomeDuracaoSono", termometroNoturno.DuracaoSonoId);
            ViewData["TipoSentimentoSonoId"] = new SelectList(_context.TipoSentimentoSono, "TipoSentimentoSonoId", "NomeTipoSentimentoSono", termometroNoturno.TipoSentimentoSonoId);
            return View(termometroNoturno);
        }

        // GET: TermometroNoturno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TermometroNoturno == null)
            {
                return NotFound();
            }

            var termometroNoturno = await _context.TermometroNoturno.FindAsync(id);
            if (termometroNoturno == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", termometroNoturno.ClienteId);
            ViewData["DuracaoSonoId"] = new SelectList(_context.DuracaoSono, "DuracaoSonoId", "NomeDuracaoSono", termometroNoturno.DuracaoSonoId);
            ViewData["TipoSentimentoSonoId"] = new SelectList(_context.TipoSentimentoSono, "TipoSentimentoSonoId", "NomeTipoSentimentoSono", termometroNoturno.TipoSentimentoSonoId);
            return View(termometroNoturno);
        }

        // POST: TermometroNoturno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermometroNoturnoId,Data,DuracaoSonoId,VezesAcordou,TipoSentimentoSonoId,ClienteId")] TermometroNoturno termometroNoturno)
        {
            if (id != termometroNoturno.TermometroNoturnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termometroNoturno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermometroNoturnoExists(termometroNoturno.TermometroNoturnoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", termometroNoturno.ClienteId);
            ViewData["DuracaoSonoId"] = new SelectList(_context.DuracaoSono, "DuracaoSonoId", "NomeDuracaoSono", termometroNoturno.DuracaoSonoId);
            ViewData["TipoSentimentoSonoId"] = new SelectList(_context.TipoSentimentoSono, "TipoSentimentoSonoId", "NomeTipoSentimentoSono", termometroNoturno.TipoSentimentoSonoId);
            return View(termometroNoturno);
        }

        // GET: TermometroNoturno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TermometroNoturno == null)
            {
                return NotFound();
            }

            var termometroNoturno = await _context.TermometroNoturno
                .Include(t => t.Cliente)
                .Include(t => t.DuracaoSono)
                .Include(t => t.TipoSentimentoSono)
                .FirstOrDefaultAsync(m => m.TermometroNoturnoId == id);
            if (termometroNoturno == null)
            {
                return NotFound();
            }

            return View(termometroNoturno);
        }

        // POST: TermometroNoturno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TermometroNoturno == null)
            {
                return Problem("Entity set 'Contexto.TermometroNoturno'  is null.");
            }
            var termometroNoturno = await _context.TermometroNoturno.FindAsync(id);
            if (termometroNoturno != null)
            {
                _context.TermometroNoturno.Remove(termometroNoturno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermometroNoturnoExists(int id)
        {
          return (_context.TermometroNoturno?.Any(e => e.TermometroNoturnoId == id)).GetValueOrDefault();
        }
    }
}
