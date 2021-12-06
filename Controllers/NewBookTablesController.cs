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
    public class NewBookTablesController : ControllerBase
    {
        private readonly AddToCartContext _context;

        public NewBookTablesController(AddToCartContext context)
        {
            _context = context;
        }

        // GET: api/NewBookTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewBookTable>>> GetNewBookTables()
        {
            return await _context.NewBookTables.ToListAsync();
        }

        // GET: api/NewBookTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewBookTable>> GetNewBookTable(int id)
        {
            var newBookTable = await _context.NewBookTables.FindAsync(id);

            if (newBookTable == null)
            {
                return NotFound();
            }

            return newBookTable;
        }

        // PUT: api/NewBookTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewBookTable(int id, NewBookTable newBookTable)
        {
            if (id != newBookTable.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(newBookTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewBookTableExists(id))
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

        // POST: api/NewBookTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewBookTable>> PostNewBookTable(NewBookTable newBookTable)
        {
            _context.NewBookTables.Add(newBookTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewBookTableExists(newBookTable.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNewBookTable", new { id = newBookTable.ProductId }, newBookTable);
        }

        // DELETE: api/NewBookTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewBookTable(int id)
        {
            var newBookTable = await _context.NewBookTables.FindAsync(id);
            if (newBookTable == null)
            {
                return NotFound();
            }

            _context.NewBookTables.Remove(newBookTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewBookTableExists(int id)
        {
            return _context.NewBookTables.Any(e => e.ProductId == id);
        }
        
    }
}
