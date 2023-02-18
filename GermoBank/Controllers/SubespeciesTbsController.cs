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
    public class SubespeciesTbsController : Controller
    {
        private readonly GermoBankUtnContext _context;

        public SubespeciesTbsController(GermoBankUtnContext context)
        {
            _context = context;
        }

        // GET: SubespeciesTbs
        public async Task<IActionResult> Index()
        {
            var germoBankUtnContext = _context.SubespeciesTbs.Include(s => s.IdEspecieFkNavigation);
            return View(await germoBankUtnContext.ToListAsync());
        }

        // GET: SubespeciesTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubespeciesTbs == null)
            {
                return NotFound();
            }

            var subespeciesTb = await _context.SubespeciesTbs
                .Include(s => s.IdEspecieFkNavigation)
                .FirstOrDefaultAsync(m => m.IdSubespeciePk == id);
            if (subespeciesTb == null)
            {
                return NotFound();
            }

            return View(subespeciesTb);
        }

        // GET: SubespeciesTbs/Create
        public IActionResult Create()
        {
            ViewData["IdEspecieFk"] = new SelectList(_context.EspeciesTbs, "IdEspeciePk", "IdEspeciePk");
            return View();
        }

        // POST: SubespeciesTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubespeciePk,NombreSubespecie,IdEspecieFk")] SubespeciesTb subespeciesTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subespeciesTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEspecieFk"] = new SelectList(_context.EspeciesTbs, "IdEspeciePk", "IdEspeciePk", subespeciesTb.IdEspecieFk);
            return View(subespeciesTb);
        }

        // GET: SubespeciesTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubespeciesTbs == null)
            {
                return NotFound();
            }

            var subespeciesTb = await _context.SubespeciesTbs.FindAsync(id);
            if (subespeciesTb == null)
            {
                return NotFound();
            }
            ViewData["IdEspecieFk"] = new SelectList(_context.EspeciesTbs, "IdEspeciePk", "IdEspeciePk", subespeciesTb.IdEspecieFk);
            return View(subespeciesTb);
        }

        // POST: SubespeciesTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubespeciePk,NombreSubespecie,IdEspecieFk")] SubespeciesTb subespeciesTb)
        {
            if (id != subespeciesTb.IdSubespeciePk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subespeciesTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubespeciesTbExists(subespeciesTb.IdSubespeciePk))
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
            ViewData["IdEspecieFk"] = new SelectList(_context.EspeciesTbs, "IdEspeciePk", "IdEspeciePk", subespeciesTb.IdEspecieFk);
            return View(subespeciesTb);
        }

        // GET: SubespeciesTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubespeciesTbs == null)
            {
                return NotFound();
            }

            var subespeciesTb = await _context.SubespeciesTbs
                .Include(s => s.IdEspecieFkNavigation)
                .FirstOrDefaultAsync(m => m.IdSubespeciePk == id);
            if (subespeciesTb == null)
            {
                return NotFound();
            }

            return View(subespeciesTb);
        }

        // POST: SubespeciesTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubespeciesTbs == null)
            {
                return Problem("Entity set 'GermoBankUtnContext.SubespeciesTbs'  is null.");
            }
            var subespeciesTb = await _context.SubespeciesTbs.FindAsync(id);
            if (subespeciesTb != null)
            {
                _context.SubespeciesTbs.Remove(subespeciesTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubespeciesTbExists(int id)
        {
          return _context.SubespeciesTbs.Any(e => e.IdSubespeciePk == id);
        }
    }
}
