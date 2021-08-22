using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CheckAdd.Data;
using CheckAdd.Models;

namespace CheckAdd.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookseriesController : ControllerBase
    {
        private readonly CheckAddContext _context;

        public BookseriesController(CheckAddContext context)
        {
            _context = context;
        }

        // GET: api/Bookseries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookserie>>> GetBookserie()
        {
            return await _context.Bookserie.ToListAsync();
        }

        // GET: api/Bookseries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookserie>> GetBookserie(int id)
        {
            var bookserie = await _context.Bookserie.FindAsync(id);

            if (bookserie == null)
            {
                return NotFound();
            }

            return bookserie;
        }

        // PUT: api/Bookseries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookserie(int id, Bookserie bookserie)
        {
            if (id != bookserie.BookserieId)
            {
                return BadRequest();
            }

            _context.Entry(bookserie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookserieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookseries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookserie>> PostBookserie(Bookserie bookserie)
        {
            _context.Bookserie.Add(bookserie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookserie", new { id = bookserie.BookserieId }, bookserie);
        }

        // DELETE: api/Bookseries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookserie(int id)
        {
            var bookserie = await _context.Bookserie.FindAsync(id);
            if (bookserie == null)
            {
                return NotFound();
            }

            _context.Bookserie.Remove(bookserie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookserieExists(int id)
        {
            return _context.Bookserie.Any(e => e.BookserieId == id);
        }
    }
}
