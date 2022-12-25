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
    public class SellCustomersController : Controller
    {
        private readonly TortoiseContext _context;

        public SellCustomersController(TortoiseContext context)
        {
            _context = context;
        }

        // GET: SellCustomers
        public async Task<IActionResult> Index()
        {
              return View(await _context.SellCustomers.ToListAsync());
        }

        // GET: SellCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellCustomers == null)
            {
                return NotFound();
            }

            var sellCustomer = await _context.SellCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellCustomer == null)
            {
                return NotFound();
            }

            return View(sellCustomer);
        }

        // GET: SellCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CName,CAddress,CPhone,CGstNo")] SellCustomer sellCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellCustomer);
        }

        // GET: SellCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellCustomers == null)
            {
                return NotFound();
            }

            var sellCustomer = await _context.SellCustomers.FindAsync(id);
            if (sellCustomer == null)
            {
                return NotFound();
            }
            return View(sellCustomer);
        }

        // POST: SellCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CName,CAddress,CPhone,CGstNo")] SellCustomer sellCustomer)
        {
            if (id != sellCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellCustomerExists(sellCustomer.Id))
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
            return View(sellCustomer);
        }

        // GET: SellCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellCustomers == null)
            {
                return NotFound();
            }

            var sellCustomer = await _context.SellCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellCustomer == null)
            {
                return NotFound();
            }

            return View(sellCustomer);
        }

        // POST: SellCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellCustomers == null)
            {
                return Problem("Entity set 'TortoiseContext.SellCustomers'  is null.");
            }
            var sellCustomer = await _context.SellCustomers.FindAsync(id);
            if (sellCustomer != null)
            {
                _context.SellCustomers.Remove(sellCustomer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellCustomerExists(int id)
        {
          return _context.SellCustomers.Any(e => e.Id == id);
        }
    }
}
