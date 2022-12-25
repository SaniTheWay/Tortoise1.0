using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tortoise1._0.Models;

namespace Tortoise1._0.Controllers
{
    public class SellFoldersController : Controller
    {
        private readonly TortoiseContext _context;

        public SellFoldersController(TortoiseContext context)
        {
            _context = context;
        }

        // GET: SellFolders
        public async Task<IActionResult> Index()
        {
              return View(await _context.SellFolders.ToListAsync());
        }

        [HttpGet]
        public IActionResult SGetFolder(int id)
        {
            var q = _context.SellFolders.Where(e => e.CId == id);
            if (q.Count() == 0) q = null;
            ViewBag.id = id;
            return View(q);
        }


        // GET: SellFolders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellFolders == null)
            {
                return NotFound();
            }

            var sellFolder = await _context.SellFolders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellFolder == null)
            {
                return NotFound();
            }

            return View(sellFolder);
        }

        // GET: SellFolders/Create
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: SellFolders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CId,Date,BillNo,Amount,CheckNo")] SellFolder sellFolder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellFolder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SGetFolder), new { id = sellFolder.CId });
            }
            return View(sellFolder);
        }

        // GET: SellFolders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellFolders == null)
            {
                return NotFound();
            }

            var sellFolder = await _context.SellFolders.FindAsync(id);
            if (sellFolder == null)
            {
                return NotFound();
            }
            return View(sellFolder);
        }

        // POST: SellFolders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CId,Date,BillNo,Amount,CheckNo")] SellFolder sellFolder)
        {
            if (id != sellFolder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellFolder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellFolderExists(sellFolder.Id))
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
            return View(sellFolder);
        }

        // GET: SellFolders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellFolders == null)
            {
                return NotFound();
            }

            var sellFolder = await _context.SellFolders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellFolder == null)
            {
                return NotFound();
            }

            return View(sellFolder);
        }

        // POST: SellFolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellFolders == null)
            {
                return Problem("Entity set 'TortoiseContext.SellFolders'  is null.");
            }
            var sellFolder = await _context.SellFolders.FindAsync(id);
            if (sellFolder != null)
            {
                _context.SellFolders.Remove(sellFolder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellFolderExists(int id)
        {
          return _context.SellFolders.Any(e => e.Id == id);
        }
    }
}
