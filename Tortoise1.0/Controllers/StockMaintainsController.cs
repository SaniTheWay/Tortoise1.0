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
    public class StockMaintainsController : Controller
    {
        private readonly TortoiseContext _context;

        public StockMaintainsController(TortoiseContext context)
        {
            _context = context;
        }

        // GET: StockMaintains
        public async Task<IActionResult> Index()
        {
              return View(await _context.StockMaintains.ToListAsync());
        }

        // GET: StockMaintains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockMaintains == null)
            {
                return NotFound();
            }

            var stockMaintain = await _context.StockMaintains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockMaintain == null)
            {
                return NotFound();
            }

            return View(stockMaintain);
        }

        // GET: StockMaintains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockMaintains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,Name,Count")] StockMaintain stockMaintain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockMaintain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockMaintain);
        }

        // GET: StockMaintains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockMaintains == null)
            {
                return NotFound();
            }

            var stockMaintain = await _context.StockMaintains.FindAsync(id);
            if (stockMaintain == null)
            {
                return NotFound();
            }
            return View(stockMaintain);
        }

        // POST: StockMaintains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Name,Count")] StockMaintain stockMaintain)
        {
            if (id != stockMaintain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockMaintain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockMaintainExists(stockMaintain.Id))
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
            return View(stockMaintain);
        }

        // GET: StockMaintains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockMaintains == null)
            {
                return NotFound();
            }

            var stockMaintain = await _context.StockMaintains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockMaintain == null)
            {
                return NotFound();
            }

            return View(stockMaintain);
        }

        // POST: StockMaintains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockMaintains == null)
            {
                return Problem("Entity set 'TortoiseContext.StockMaintains'  is null.");
            }
            var stockMaintain = await _context.StockMaintains.FindAsync(id);
            if (stockMaintain != null)
            {
                _context.StockMaintains.Remove(stockMaintain);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockMaintainExists(int id)
        {
          return _context.StockMaintains.Any(e => e.Id == id);
        }
    }
}
