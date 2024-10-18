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
    public class TipoEmocaoController : Controller
    {
        private readonly Contexto _context;

        public TipoEmocaoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoEmocao
        public async Task<IActionResult> Index()
        {
              return _context.TipoEmocao != null ? 
                          View(await _context.TipoEmocao.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoEmocao'  is null.");
        }

        // GET: TipoEmocao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEmocao == null)
            {
                return NotFound();
            }

            var tipoEmocao = await _context.TipoEmocao
                .FirstOrDefaultAsync(m => m.TipoEmocaoId == id);
            if (tipoEmocao == null)
            {
                return NotFound();
            }

            return View(tipoEmocao);
        }

        // GET: TipoEmocao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEmocao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoEmocaoId,NomeTipoEmocao")] TipoEmocao tipoEmocao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEmocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEmocao);
        }

        // GET: TipoEmocao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEmocao == null)
            {
                return NotFound();
            }

            var tipoEmocao = await _context.TipoEmocao.FindAsync(id);
            if (tipoEmocao == null)
            {
                return NotFound();
            }
            return View(tipoEmocao);
        }

        // POST: TipoEmocao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoEmocaoId,NomeTipoEmocao")] TipoEmocao tipoEmocao)
        {
            if (id != tipoEmocao.TipoEmocaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEmocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEmocaoExists(tipoEmocao.TipoEmocaoId))
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
            return View(tipoEmocao);
        }

        // GET: TipoEmocao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEmocao == null)
            {
                return NotFound();
            }

            var tipoEmocao = await _context.TipoEmocao
                .FirstOrDefaultAsync(m => m.TipoEmocaoId == id);
            if (tipoEmocao == null)
            {
                return NotFound();
            }

            return View(tipoEmocao);
        }

        // POST: TipoEmocao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEmocao == null)
            {
                return Problem("Entity set 'Contexto.TipoEmocao'  is null.");
            }
            var tipoEmocao = await _context.TipoEmocao.FindAsync(id);
            if (tipoEmocao != null)
            {
                _context.TipoEmocao.Remove(tipoEmocao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEmocaoExists(int id)
        {
          return (_context.TipoEmocao?.Any(e => e.TipoEmocaoId == id)).GetValueOrDefault();
        }
    }
}
