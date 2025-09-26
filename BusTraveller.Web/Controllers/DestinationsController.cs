using BusTraveller.Web.Data;
using BusTraveller.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Pkcs;

namespace BusTraveller.Web.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var destinations = await _context.Destinations.ToListAsync();
            if (destinations == null) return NotFound();
            return View(destinations);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var destination = await _context.Destinations.FindAsync(id);
            if(destination== null)
            {
                return NotFound();
            }

            return View(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Destination destination)
        {
            if(id != destination.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid) {
                _context.Update(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            var destination = await _context.Destinations.FirstOrDefaultAsync(x => x.Id == id);
            if(destination == null)
            {
                return NotFound();
            }


            return View(destination);
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            if (destination != null)
            {
                _context.Destinations.Remove(destination);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
