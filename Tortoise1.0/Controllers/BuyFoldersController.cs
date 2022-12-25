using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Tortoise1._0.Models;

namespace Tortoise1._0.Controllers
{
    public class BuyFoldersController : Controller
    {
        private readonly TortoiseContext _db;

        public BuyFoldersController(TortoiseContext db)
        {
            _db= db;
        }

        // GET: BuyFolders
        public async Task<IActionResult> Index()
        {
              return View(await _db.BuyFolders.ToListAsync());
        }

        //[Route("{}")]
        [HttpGet]
        public IActionResult GetFolder(int id)
        {
            var q = _db.BuyFolders.Where(e => e.CId == id);
            if (q.Count() == 0) q = null;
            ViewBag.id = id;
            return View(q);
        }

        // GET: BuyFolders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.BuyFolders == null)
            {
                return NotFound();
            }

            var buyFolder = await _db.BuyFolders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyFolder == null)
            {
                return NotFound();
            }

            return View(buyFolder);
        }

        // GET: BuyFolders/Create
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: BuyFolders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CId,Date,BillNo,Amount,CheckNo")] BuyFolder buyFolder)
        {
            if (ModelState.IsValid)
            {
                _db.Add(buyFolder);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(GetFolder), new {id = buyFolder.CId});
            }
            return View(buyFolder);
        }

        // GET: BuyFolders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.BuyFolders == null)
            {
                return NotFound();
            }

            var buyFolder = await _db.BuyFolders.FindAsync(id);
            if (buyFolder == null)
            {
                return NotFound();
            }
            return View(buyFolder);
        }

        // POST: BuyFolders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CId,Date,BillNo,Amount,CheckNo")] BuyFolder buyFolder)
        {
            if (id != buyFolder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(buyFolder);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyFolderExists(buyFolder.Id))
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
            return View(buyFolder);
        }

        // GET: BuyFolders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.BuyFolders == null)
            {
                return NotFound();
            }

            var buyFolder = await _db.BuyFolders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyFolder == null)
            {
                return NotFound();
            }

            return View(buyFolder);
        }

        // POST: BuyFolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.BuyFolders == null)
            {
                return Problem("Entity set 'TortoiseContext.BuyFolders'  is null.");
            }
            var buyFolder = await _db.BuyFolders.FindAsync(id);
            if (buyFolder != null)
            {
                _db.BuyFolders.Remove(buyFolder);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyFolderExists(int id)
        {
          return _db.BuyFolders.Any(e => e.Id == id);
        }
    }
}
