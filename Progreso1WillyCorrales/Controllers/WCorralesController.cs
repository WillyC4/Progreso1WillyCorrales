using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progreso1WillyCorrales.Data;
using Progreso1WillyCorrales.Models;

namespace Progreso1WillyCorrales.Controllers
{
    public class WCorralesController : Controller
    {
        private readonly Progreso1WillyCorralesContext _context;

        public WCorralesController(Progreso1WillyCorralesContext context)
        {
            _context = context;
        }

        // GET: WCorrales
        public async Task<IActionResult> Index()
        {
            var progreso1WillyCorralesContext = _context.WCorrales.Include(w => w.Carreras);
            return View(await progreso1WillyCorralesContext.ToListAsync());
        }

        // GET: WCorrales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wCorrales = await _context.WCorrales
                .Include(w => w.Carreras)
                .FirstOrDefaultAsync(m => m.id == id);
            if (wCorrales == null)
            {
                return NotFound();
            }

            return View(wCorrales);
        }

        // GET: WCorrales/Create
        public IActionResult Create()
        {
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "nombre_carrera");
            return View();
        }

        // POST: WCorrales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,decima,SiNo,fecha,carreraID")] WCorrales wCorrales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wCorrales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "nombre_carrera", wCorrales.carreraID);
            return View(wCorrales);
        }

        // GET: WCorrales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wCorrales = await _context.WCorrales.FindAsync(id);
            if (wCorrales == null)
            {
                return NotFound();
            }
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "nombre_carrera", wCorrales.carreraID);
            return View(wCorrales);
        }

        // POST: WCorrales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,decima,SiNo,fecha,carreraID")] WCorrales wCorrales)
        {
            if (id != wCorrales.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wCorrales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WCorralesExists(wCorrales.id))
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
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "nombre_carrera", wCorrales.carreraID);
            return View(wCorrales);
        }

        // GET: WCorrales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wCorrales = await _context.WCorrales
                .Include(w => w.Carreras)
                .FirstOrDefaultAsync(m => m.id == id);
            if (wCorrales == null)
            {
                return NotFound();
            }

            return View(wCorrales);
        }

        // POST: WCorrales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wCorrales = await _context.WCorrales.FindAsync(id);
            if (wCorrales != null)
            {
                _context.WCorrales.Remove(wCorrales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WCorralesExists(int id)
        {
            return _context.WCorrales.Any(e => e.id == id);
        }
    }
}
