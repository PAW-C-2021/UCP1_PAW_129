using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ucp1_129.Models;

namespace ucp1_129.Controllers
{
    public class KasirsController : Controller
    {
        private readonly ApotekerContext _context;

        public KasirsController(ApotekerContext context)
        {
            _context = context;
        }

        // GET: Kasirs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kasir.ToListAsync());
        }

        // GET: Kasirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kasir = await _context.Kasir
                .FirstOrDefaultAsync(m => m.IdKasir == id);
            if (kasir == null)
            {
                return NotFound();
            }

            return View(kasir);
        }

        // GET: Kasirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kasirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKasir,Nama,JenisKelamin,Umur")] Kasir kasir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kasir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kasir);
        }

        // GET: Kasirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kasir = await _context.Kasir.FindAsync(id);
            if (kasir == null)
            {
                return NotFound();
            }
            return View(kasir);
        }

        // POST: Kasirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKasir,Nama,JenisKelamin,Umur")] Kasir kasir)
        {
            if (id != kasir.IdKasir)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kasir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KasirExists(kasir.IdKasir))
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
            return View(kasir);
        }

        // GET: Kasirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kasir = await _context.Kasir
                .FirstOrDefaultAsync(m => m.IdKasir == id);
            if (kasir == null)
            {
                return NotFound();
            }

            return View(kasir);
        }

        // POST: Kasirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kasir = await _context.Kasir.FindAsync(id);
            _context.Kasir.Remove(kasir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KasirExists(int id)
        {
            return _context.Kasir.Any(e => e.IdKasir == id);
        }
    }
}
