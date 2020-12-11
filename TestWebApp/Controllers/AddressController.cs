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
            return View(_context.Addresses.Include(a => a.Country).ToList());
        }

        public IActionResult Customer(int? id)
        {
            var addresses = _context.Addresses
                .Where(a => a.CustomerId == id)
                .Include(a => a.Country).ToList();

            
            return View(addresses);
        }


        public IActionResult AddAddress(int? id)
        {
            var customer = _context.Customers.Find(id);
            TempData["Customer"] = customer;
            
            PopulateCountriesDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress([Bind("CustomerId,StreetAddress,CountryId,Zip")] Address address)
        {

            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Customers");
            }

            PopulateCountriesDropDownList(address.CountryId);

            return View(address);
        }
        
        private void PopulateCountriesDropDownList(object selectedCountry = null)
        {
            var countryQuery = from d in _context.Countries
                orderby d.Name
                select d;
            ViewBag.CountryId = new SelectList(countryQuery.AsNoTracking(), "CountryId", "Name", selectedCountry);
        }

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

        public async Task<IActionResult> EditAddress(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
             .Include(o => o.Customer)
             .FirstOrDefaultAsync(m => m.Id == id);

            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(int id, [Bind("Id,CustomerId,StreetAddress,Country,Zip,CountryId")] Address address)
        {
            if(id != address.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!CustomerExists(address.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Customers");
            }
            return View(address);
        }

        private bool CustomerExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DeleteAddress(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        [HttpPost, ActionName("DeleteAddress")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Customers");
        }
    }
}
