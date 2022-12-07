using DWHub.Data;
using DWHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWHub.Controllers
{
    public class WatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Watches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Watch.ToListAsync());
        }
   
        public IActionResult SearchForm()
        {
            return View();
        }


        public async Task<IActionResult> WatchList()
        {
            return View(await _context.Watch.ToListAsync());
        }

        public async Task<IActionResult> SearchResult(string Title)
        { 
            return View("Index", await _context.Watch.Where(a=>a.Title.Contains(Title)).ToListAsync());
        }

        // GET: Watches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        // GET: Watches/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Company"] = new SelectList(_context.Company, "Id", "Name");
            return View();
        }


       

        // POST: Watches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,URL,Price,CompanyID")] Watch watch, List<int> Companies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(watch);
        }

        // GET: Watches/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watch.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }
            return View(watch);
        }

        // POST: Watches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,URL,Price")] Watch watch)
        {
            if (id != watch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchExists(watch.Id))
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
            return View(watch);
        }

        // GET: Watches/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        // POST: Watches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var watch = await _context.Watch.FindAsync(id);
            _context.Watch.Remove(watch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchExists(int id)
        {
            return _context.Watch.Any(e => e.Id == id);
        }
    }
}
