using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GermoBank.Models;

namespace GermoBank.Controllers
{
    public class GenerosTbsController : Controller
    {
        private readonly GermoBankUtnContext _context;

        public GenerosTbsController(GermoBankUtnContext context)
        {
            _context = context;
        }

        // GET: GenerosTbs
        public async Task<IActionResult> Index()
        {
            var germoBankUtnContext = _context.GenerosTbs.Include(g => g.IdFamiliaFkNavigation);
            return View(await germoBankUtnContext.ToListAsync());
        }

        // GET: GenerosTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GenerosTbs == null)
            {
                return NotFound();
            }

            var generosTb = await _context.GenerosTbs
                .Include(g => g.IdFamiliaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdGeneroPk == id);
            if (generosTb == null)
            {
                return NotFound();
            }

            return View(generosTb);
        }

        // GET: GenerosTbs/Create
        public IActionResult Create()
        {
            ViewData["IdFamiliaFk"] = new SelectList(_context.FamiliasTbs, "IdFamiliaPk", "IdFamiliaPk");
            return View();
        }

        // POST: GenerosTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGeneroPk,NombreGenero,IdFamiliaFk")] GenerosTb generosTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generosTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFamiliaFk"] = new SelectList(_context.FamiliasTbs, "IdFamiliaPk", "IdFamiliaPk", generosTb.IdFamiliaFk);
            return View(generosTb);
        }

        // GET: GenerosTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GenerosTbs == null)
            {
                return NotFound();
            }

            var generosTb = await _context.GenerosTbs.FindAsync(id);
            if (generosTb == null)
            {
                return NotFound();
            }
            ViewData["IdFamiliaFk"] = new SelectList(_context.FamiliasTbs, "IdFamiliaPk", "IdFamiliaPk", generosTb.IdFamiliaFk);
            return View(generosTb);
        }

        // POST: GenerosTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGeneroPk,NombreGenero,IdFamiliaFk")] GenerosTb generosTb)
        {
            if (id != generosTb.IdGeneroPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generosTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenerosTbExists(generosTb.IdGeneroPk))
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
            ViewData["IdFamiliaFk"] = new SelectList(_context.FamiliasTbs, "IdFamiliaPk", "IdFamiliaPk", generosTb.IdFamiliaFk);
            return View(generosTb);
        }

        // GET: GenerosTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GenerosTbs == null)
            {
                return NotFound();
            }

            var generosTb = await _context.GenerosTbs
                .Include(g => g.IdFamiliaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdGeneroPk == id);
            if (generosTb == null)
            {
                return NotFound();
            }

            return View(generosTb);
        }

        // POST: GenerosTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GenerosTbs == null)
            {
                return Problem("Entity set 'GermoBankUtnContext.GenerosTbs'  is null.");
            }
            var generosTb = await _context.GenerosTbs.FindAsync(id);
            if (generosTb != null)
            {
                _context.GenerosTbs.Remove(generosTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenerosTbExists(int id)
        {
          return _context.GenerosTbs.Any(e => e.IdGeneroPk == id);
        }
    }
}
