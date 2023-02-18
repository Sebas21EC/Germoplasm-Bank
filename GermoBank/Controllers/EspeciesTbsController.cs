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
    public class EspeciesTbsController : Controller
    {
        private readonly GermoBankUtnContext _context;

        public EspeciesTbsController(GermoBankUtnContext context)
        {
            _context = context;
        }

        // GET: EspeciesTbs
        public async Task<IActionResult> Index()
        {
            var germoBankUtnContext = _context.EspeciesTbs.Include(e => e.IdGeneroFkNavigation);
            return View(await germoBankUtnContext.ToListAsync());
        }

        // GET: EspeciesTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EspeciesTbs == null)
            {
                return NotFound();
            }

            var especiesTb = await _context.EspeciesTbs
                .Include(e => e.IdGeneroFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEspeciePk == id);
            if (especiesTb == null)
            {
                return NotFound();
            }

            return View(especiesTb);
        }

        // GET: EspeciesTbs/Create
        public IActionResult Create()
        {
            ViewData["IdGeneroFk"] = new SelectList(_context.GenerosTbs, "IdGeneroPk", "IdGeneroPk");
            return View();
        }

        // POST: EspeciesTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspeciePk,NombreEspecie,IdGeneroFk")] EspeciesTb especiesTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especiesTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGeneroFk"] = new SelectList(_context.GenerosTbs, "IdGeneroPk", "IdGeneroPk", especiesTb.IdGeneroFk);
            return View(especiesTb);
        }

        // GET: EspeciesTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EspeciesTbs == null)
            {
                return NotFound();
            }

            var especiesTb = await _context.EspeciesTbs.FindAsync(id);
            if (especiesTb == null)
            {
                return NotFound();
            }
            ViewData["IdGeneroFk"] = new SelectList(_context.GenerosTbs, "IdGeneroPk", "IdGeneroPk", especiesTb.IdGeneroFk);
            return View(especiesTb);
        }

        // POST: EspeciesTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspeciePk,NombreEspecie,IdGeneroFk")] EspeciesTb especiesTb)
        {
            if (id != especiesTb.IdEspeciePk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especiesTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspeciesTbExists(especiesTb.IdEspeciePk))
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
            ViewData["IdGeneroFk"] = new SelectList(_context.GenerosTbs, "IdGeneroPk", "IdGeneroPk", especiesTb.IdGeneroFk);
            return View(especiesTb);
        }

        // GET: EspeciesTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EspeciesTbs == null)
            {
                return NotFound();
            }

            var especiesTb = await _context.EspeciesTbs
                .Include(e => e.IdGeneroFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEspeciePk == id);
            if (especiesTb == null)
            {
                return NotFound();
            }

            return View(especiesTb);
        }

        // POST: EspeciesTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EspeciesTbs == null)
            {
                return Problem("Entity set 'GermoBankUtnContext.EspeciesTbs'  is null.");
            }
            var especiesTb = await _context.EspeciesTbs.FindAsync(id);
            if (especiesTb != null)
            {
                _context.EspeciesTbs.Remove(especiesTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspeciesTbExists(int id)
        {
          return _context.EspeciesTbs.Any(e => e.IdEspeciePk == id);
        }
    }
}
