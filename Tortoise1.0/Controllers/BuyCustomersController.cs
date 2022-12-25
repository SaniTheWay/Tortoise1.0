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
    public class BuyCustomersController : Controller
    {
        private readonly TortoiseContext _context;

        public BuyCustomersController(TortoiseContext context)
        {
            _context = context;
        }

        // GET: BuyCustomers
        public async Task<IActionResult> Index()
        {
              return View(await _context.BuyCustomers.ToListAsync());
        }

        // GET: BuyCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuyCustomers == null)
            {
                return NotFound();
            }

            var buyCustomer = await _context.BuyCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyCustomer == null)
            {
                return NotFound();
            }

            return View(buyCustomer);
        }

        // GET: BuyCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuyCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CName,CAddress,CPhone,CGstNo")] BuyCustomer buyCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyCustomer);
        }
        // GET: BuyCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuyCustomers == null)
            {
                return NotFound();
            }

            var buyCustomer = await _context.BuyCustomers.FindAsync(id);
            if (buyCustomer == null)
            {
                return NotFound();
            }
            return View(buyCustomer);
        }

        // POST: BuyCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CName,CAddress,CPhone,CGstNo")] BuyCustomer buyCustomer)
        {
            if (id != buyCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyCustomerExists(buyCustomer.Id))
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
            return View(buyCustomer);
        }

        // GET: BuyCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuyCustomers == null)
            {
                return NotFound();
            }

            var buyCustomer = await _context.BuyCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyCustomer == null)
            {
                return NotFound();
            }

            return View(buyCustomer);
        }

        // POST: BuyCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuyCustomers == null)
            {
                return Problem("Entity set 'TortoiseContext.BuyCustomers'  is null.");
            }
            var buyCustomer = await _context.BuyCustomers.FindAsync(id);
            if (buyCustomer != null)
            {
                _context.BuyCustomers.Remove(buyCustomer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyCustomerExists(int id)
        {
          return _context.BuyCustomers.Any(e => e.Id == id);
        }
    }
}
