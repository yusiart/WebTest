using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        public CustomerContext _context { get; }

        public AddressController(CustomerContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var customerContext = _context.Addresses.Include(o => o.Customer);
            return View(await customerContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

    }
}
