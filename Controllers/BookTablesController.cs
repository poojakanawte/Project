using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookDatabaseApi.Models;

namespace BookDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTablesController : ControllerBase
    {
        private readonly AddToCartContext _context;

        public BookTablesController(AddToCartContext context)
        {
            _context = context;
        }

        // GET: api/BookTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTable>>> GetBookTables()
        {
            return await _context.BookTables.ToListAsync();
        }

        // GET: api/BookTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookTable>> GetBookTable(int id)
        {
            var bookTable = await _context.BookTables.FindAsync(id);

            if (bookTable == null)
            {
                return NotFound();
            }

            return bookTable;
        }

        // PUT: api/BookTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookTable(int id, BookTable bookTable)
        {
            if (id != bookTable.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(bookTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTableExists(id))
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

        // POST: api/BookTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookTable>> PostBookTable(BookTable bookTable)
        {
            _context.BookTables.Add(bookTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookTableExists(bookTable.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookTable", new { id = bookTable.ProductId }, bookTable);
        }

        // DELETE: api/BookTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookTable(int id)
        {
            var bookTable = await _context.BookTables.FindAsync(id);
            if (bookTable == null)
            {
                return NotFound();
            }

            _context.BookTables.Remove(bookTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookTableExists(int id)
        {
            return _context.BookTables.Any(e => e.ProductId == id);
        }
    }
}
