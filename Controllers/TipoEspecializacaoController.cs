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
    public class TipoEspecializacaoController : Controller
    {
        private readonly Contexto _context;

        public TipoEspecializacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoEspecializacao
        public async Task<IActionResult> Index()
        {
              return _context.TipoEspecializacao != null ? 
                          View(await _context.TipoEspecializacao.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoEspecializacao'  is null.");
        }

        // GET: TipoEspecializacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEspecializacao == null)
            {
                return NotFound();
            }

            var tipoEspecializacao = await _context.TipoEspecializacao
                .FirstOrDefaultAsync(m => m.TipoEspecializacaoId == id);
            if (tipoEspecializacao == null)
            {
                return NotFound();
            }

            return View(tipoEspecializacao);
        }

        // GET: TipoEspecializacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEspecializacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoEspecializacaoId,NomeTipoEspecializacao")] TipoEspecializacao tipoEspecializacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEspecializacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEspecializacao);
        }

        // GET: TipoEspecializacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEspecializacao == null)
            {
                return NotFound();
            }

            var tipoEspecializacao = await _context.TipoEspecializacao.FindAsync(id);
            if (tipoEspecializacao == null)
            {
                return NotFound();
            }
            return View(tipoEspecializacao);
        }

        // POST: TipoEspecializacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoEspecializacaoId,NomeTipoEspecializacao")] TipoEspecializacao tipoEspecializacao)
        {
            if (id != tipoEspecializacao.TipoEspecializacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEspecializacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEspecializacaoExists(tipoEspecializacao.TipoEspecializacaoId))
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
            return View(tipoEspecializacao);
        }

        // GET: TipoEspecializacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEspecializacao == null)
            {
                return NotFound();
            }

            var tipoEspecializacao = await _context.TipoEspecializacao
                .FirstOrDefaultAsync(m => m.TipoEspecializacaoId == id);
            if (tipoEspecializacao == null)
            {
                return NotFound();
            }

            return View(tipoEspecializacao);
        }

        // POST: TipoEspecializacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEspecializacao == null)
            {
                return Problem("Entity set 'Contexto.TipoEspecializacao'  is null.");
            }
            var tipoEspecializacao = await _context.TipoEspecializacao.FindAsync(id);
            if (tipoEspecializacao != null)
            {
                _context.TipoEspecializacao.Remove(tipoEspecializacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEspecializacaoExists(int id)
        {
          return (_context.TipoEspecializacao?.Any(e => e.TipoEspecializacaoId == id)).GetValueOrDefault();
        }
    }
}
