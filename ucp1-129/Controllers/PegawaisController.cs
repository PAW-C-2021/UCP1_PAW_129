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
    public class PegawaisController : Controller
    {
        private readonly ApotekerContext _context;

        public PegawaisController(ApotekerContext context)
        {
            _context = context;
        }

        // GET: Pegawais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pegawai.ToListAsync());
        }

        // GET: Pegawais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai
                .FirstOrDefaultAsync(m => m.IdPegawai == id);
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        // GET: Pegawais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pegawais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPegawai,NamaPegawai,JenisKelamin,Umur")] Pegawai pegawai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pegawai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pegawai);
        }

        // GET: Pegawais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai.FindAsync(id);
            if (pegawai == null)
            {
                return NotFound();
            }
            return View(pegawai);
        }

        // POST: Pegawais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPegawai,NamaPegawai,JenisKelamin,Umur")] Pegawai pegawai)
        {
            if (id != pegawai.IdPegawai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pegawai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PegawaiExists(pegawai.IdPegawai))
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
            return View(pegawai);
        }

        // GET: Pegawais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai
                .FirstOrDefaultAsync(m => m.IdPegawai == id);
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        // POST: Pegawais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pegawai = await _context.Pegawai.FindAsync(id);
            _context.Pegawai.Remove(pegawai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PegawaiExists(int id)
        {
            return _context.Pegawai.Any(e => e.IdPegawai == id);
        }
    }
}
