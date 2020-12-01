using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{ 
    
    public class AddressController : Controller
    {
        public CustomerContext _context { get; }

        public AddressController(CustomerContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            return View(_context.Addresses.Include(a => a.Customer).ToList());
        }

        public async Task<IActionResult> Customer(int? id)
        {
            var addresses = _context.Addresses
                .Where(a => a.CustomerId == id)
                .Include(a => a.Customer).ToList();

            
            return View(addresses);
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,StreetAddress,Country,Zip,CountryId")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", address.CustomerId);
            return View(address);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", address.CustomerId);
            return View(address);
        }

        //Addresses Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,StreetAddress,Country,Zip,CountryId")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExist(address.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", address.CustomerId);
            return View(address);
        }

        private bool AddressExist(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }

    }
}
