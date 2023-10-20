using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class SachController : Controller
    {
        private readonly QLSACHContext _context;

        public SachController(QLSACHContext context)
        {
            _context = context;
        }

        // GET: Sach
        public async Task<IActionResult> Index()
        {
              return _context.Saches != null ? 
                          View(await _context.Saches.ToListAsync()) :
                          Problem("Entity set 'QLSACHContext.Saches'  is null.");
        }

        // GET: Sach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Saches == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .FirstOrDefaultAsync(m => m.Masach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Sach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masach,Tensach,Sotrang,Ngonngu,Tacgia,Nxb,Namxb,Anhbia,Mota")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sach);
        }

        // GET: Sach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Saches == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            return View(sach);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Masach,Tensach,Sotrang,Ngonngu,Tacgia,Nxb,Namxb,Anhbia,Mota")] Sach sach)
        {
            if (id != sach.Masach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.Masach))
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
            return View(sach);
        }

        // GET: Sach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Saches == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .FirstOrDefaultAsync(m => m.Masach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Saches == null)
            {
                return Problem("Entity set 'QLSACHContext.Saches'  is null.");
            }
            var sach = await _context.Saches.FindAsync(id);
            if (sach != null)
            {
                _context.Saches.Remove(sach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
          return (_context.Saches?.Any(e => e.Masach == id)).GetValueOrDefault();
        }
    }
}
