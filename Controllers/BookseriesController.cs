using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckAdd.Data;
using CheckAdd.Models;

namespace CheckAdd.Controllers
{
    public class BookseriesController : Controller
    {
        private readonly CheckAddContext _context;

        public BookseriesController(CheckAddContext context)
        {
            _context = context;
        }

        // GET: Bookseries
        public async Task<IActionResult> Index(string searchString)
        {
            var bookserie = from m in _context.Bookserie
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                bookserie = bookserie.Where(s => s.Title.Contains(searchString));
            }

            return View(await bookserie.ToListAsync());
        }



        // GET: Bookseries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookserie = await _context.Bookserie
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookserieId == id);
            if (bookserie == null)
            {
                return NotFound();
            }

            return View(bookserie);
        }

        // GET: Bookseries/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Name");
            return View();
        }

        // POST: Bookseries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookserieId,AuthorId,GenreId,Title,Price")] Bookserie bookserie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookserie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Name", bookserie.GenreId);
            return View(bookserie);
        }

        // GET: Bookseries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookserie = await _context.Bookserie.FindAsync(id);
            if (bookserie == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Name", bookserie.GenreId);
            return View(bookserie);
        }

        // POST: Bookseries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookserieId,AuthorId,GenreId,Title,Price")] Bookserie bookserie)
        {
            if (id != bookserie.BookserieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookserie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookserieExists(bookserie.BookserieId))
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
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Name", bookserie.GenreId);
            return View(bookserie);
        }

        // GET: Bookseries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookserie = await _context.Bookserie
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookserieId == id);
            if (bookserie == null)
            {
                return NotFound();
            }

            return View(bookserie);
        }

        // POST: Bookseries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookserie = await _context.Bookserie.FindAsync(id);
            _context.Bookserie.Remove(bookserie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookserieExists(int id)
        {
            return _context.Bookserie.Any(e => e.BookserieId == id);
        }
    }
}
