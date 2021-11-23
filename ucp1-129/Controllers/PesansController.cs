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
    public class PesansController : Controller
    {
        private readonly ApotekerContext _context;

        public PesansController(ApotekerContext context)
        {
            _context = context;
        }

        // GET: Pesans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pesan.ToListAsync());
        }

        // GET: Pesans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesan = await _context.Pesan
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pesan == null)
            {
                return NotFound();
            }

            return View(pesan);
        }

        // GET: Pesans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pesans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPesanan,NamaObat,Harga")] Pesan pesan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pesan);
        }

        // GET: Pesans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesan = await _context.Pesan.FindAsync(id);
            if (pesan == null)
            {
                return NotFound();
            }
            return View(pesan);
        }

        // POST: Pesans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPesanan,NamaObat,Harga")] Pesan pesan)
        {
            if (id != pesan.IdPesanan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesanExists(pesan.IdPesanan))
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
            return View(pesan);
        }

        // GET: Pesans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesan = await _context.Pesan
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pesan == null)
            {
                return NotFound();
            }

            return View(pesan);
        }

        // POST: Pesans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pesan = await _context.Pesan.FindAsync(id);
            _context.Pesan.Remove(pesan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesanExists(int id)
        {
            return _context.Pesan.Any(e => e.IdPesanan == id);
        }
    }
}
