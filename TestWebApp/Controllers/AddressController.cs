using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{ 
    
    public class AddressController : Controller
    {
        public CustomerContext Context { get; }

        public AddressController(CustomerContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            return View(Context.Addresses.Include(a => a.Country).ToList());
        }

        public IActionResult Customer(int? id)
        {
            var addresses = Context.Addresses
                .Where(a => a.CustomerId == id)
                .Include(a => a.Country).ToList();
            
            return View(addresses);
        }


        public IActionResult AddAddress(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(int id, [Bind("AddressId,StreetAddress,CountryId,Zip")] Address address)
        {
            address.CustomerId = id;
            
            if (ModelState.IsValid)
            {
                Context.Add(address);
                await Context.SaveChangesAsync();
                return RedirectToAction("Index", "Customers");
            }

            return View(address);
        }
        
        public async Task<IActionResult> EditAddress(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await Context.Addresses
             .Include(o => o.Customer)
             .FirstOrDefaultAsync(m => m.AddressId == id);

            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(int id, [Bind("AddressId,CustomerId,StreetAddress,Country,Zip,CountryId")] Address address)
        {
            if(id != address.AddressId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    Context.Update(address);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!CustomerExists(address.AddressId))
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
            return Context.Addresses.Any(e => e.AddressId == id);
        }

        public async Task<IActionResult> DeleteAddress(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await Context.Addresses
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.AddressId == id);

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
            var address = await Context.Addresses.FindAsync(id);
            Context.Addresses.Remove(address);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index", "Customers");
        }
    }
}
