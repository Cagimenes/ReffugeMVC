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
    public class ProfissionalController : Controller
    {
        private readonly Contexto _context;

        public ProfissionalController(Contexto context)
        {
            _context = context;
        }

        // GET: Profissional
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.Profissional != null ?
                          View(await _context.Profissional
                          .Include(x => x.TipoEspecializacao).ToListAsync()) :
                          Problem("Entity set 'Contexto.Profissional'  is null.");
            }
            else
            {
                var profissional =
                    _context.Profissional
                    .Include(x => x.TipoEspecializacao)
                    .Where(x => x.NomeProfissional.Contains(pesquisa) || x.TipoEspecializacao.NomeTipoEspecializacao.Contains(pesquisa))
                    .OrderBy(x => x.NomeProfissional);

                return View(profissional);
            }
        }

        // GET: Profissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profissional == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional
                .Include(p => p.TipoEspecializacao)
                .FirstOrDefaultAsync(m => m.ProfissionalId == id);
            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // GET: Profissional/Create
        public IActionResult Create()
        {
            ViewData["TipoEspecializacaoId"] = new SelectList(_context.TipoEspecializacao, "TipoEspecializacaoId", "NomeTipoEspecializacao");
            return View();
        }

        // POST: Profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfissionalId,NomeProfissional,TipoEspecializacaoId,DescricaoProfissional")] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoEspecializacaoId"] = new SelectList(_context.TipoEspecializacao, "TipoEspecializacaoId", "NomeTipoEspecializacao", profissional.TipoEspecializacaoId);
            return View(profissional);
        }

        // GET: Profissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profissional == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional.FindAsync(id);
            if (profissional == null)
            {
                return NotFound();
            }
            ViewData["TipoEspecializacaoId"] = new SelectList(_context.TipoEspecializacao, "TipoEspecializacaoId", "NomeTipoEspecializacao", profissional.TipoEspecializacaoId);
            return View(profissional);
        }

        // POST: Profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfissionalId,NomeProfissional,TipoEspecializacaoId,DescricaoProfissional")] Profissional profissional)
        {
            if (id != profissional.ProfissionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalExists(profissional.ProfissionalId))
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
            ViewData["TipoEspecializacaoId"] = new SelectList(_context.TipoEspecializacao, "TipoEspecializacaoId", "NomeTipoEspecializacao", profissional.TipoEspecializacaoId);
            return View(profissional);
        }

        // GET: Profissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profissional == null)
            {
                return NotFound();
            }

            var profissional = await _context.Profissional
                .Include(p => p.TipoEspecializacao)
                .FirstOrDefaultAsync(m => m.ProfissionalId == id);
            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // POST: Profissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profissional == null)
            {
                return Problem("Entity set 'Contexto.Profissional'  is null.");
            }
            var profissional = await _context.Profissional.FindAsync(id);
            if (profissional != null)
            {
                _context.Profissional.Remove(profissional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalExists(int id)
        {
          return (_context.Profissional?.Any(e => e.ProfissionalId == id)).GetValueOrDefault();
        }
    }
}
