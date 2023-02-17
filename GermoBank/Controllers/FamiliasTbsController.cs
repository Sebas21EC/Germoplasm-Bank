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
    public class FamiliasTbsController : Controller
    {
        private readonly GermoBankUtnContext _context;

        public FamiliasTbsController(GermoBankUtnContext context)
        {
            _context = context;
        }

        // GET: FamiliasTbs
        public async Task<IActionResult> Index()
        {
              return View(await _context.FamiliasTbs.ToListAsync());
        }

        // GET: FamiliasTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FamiliasTbs == null)
            {
                return NotFound();
            }

            var familiasTb = await _context.FamiliasTbs
                .FirstOrDefaultAsync(m => m.IdFamiliaPk == id);
            if (familiasTb == null)
            {
                return NotFound();
            }

            return View(familiasTb);
        }

        // GET: FamiliasTbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamiliasTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFamiliaPk,NombreFamilia")] FamiliasTb familiasTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiasTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familiasTb);
        }

        // GET: FamiliasTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FamiliasTbs == null)
            {
                return NotFound();
            }

            var familiasTb = await _context.FamiliasTbs.FindAsync(id);
            if (familiasTb == null)
            {
                return NotFound();
            }
            return View(familiasTb);
        }

        // POST: FamiliasTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFamiliaPk,NombreFamilia")] FamiliasTb familiasTb)
        {
            if (id != familiasTb.IdFamiliaPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiasTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliasTbExists(familiasTb.IdFamiliaPk))
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
            return View(familiasTb);
        }

        // GET: FamiliasTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FamiliasTbs == null)
            {
                return NotFound();
            }

            var familiasTb = await _context.FamiliasTbs
                .FirstOrDefaultAsync(m => m.IdFamiliaPk == id);
            if (familiasTb == null)
            {
                return NotFound();
            }

            return View(familiasTb);
        }

        // POST: FamiliasTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FamiliasTbs == null)
            {
                return Problem("Entity set 'GermoBankUtnContext.FamiliasTbs'  is null.");
            }
            var familiasTb = await _context.FamiliasTbs.FindAsync(id);
            if (familiasTb != null)
            {
                _context.FamiliasTbs.Remove(familiasTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliasTbExists(int id)
        {
          return _context.FamiliasTbs.Any(e => e.IdFamiliaPk == id);
        }
    }
}
