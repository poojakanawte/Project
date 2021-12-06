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
    public class InstrumentTablesController : ControllerBase
    {
        private readonly AddToCartContext _context;

        public InstrumentTablesController(AddToCartContext context)
        {
            _context = context;
        }

        // GET: api/InstrumentTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstrumentTable>>> GetInstrumentTables()
        {
            return await _context.InstrumentTables.ToListAsync();
        }

        // GET: api/InstrumentTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstrumentTable>> GetInstrumentTable(int id)
        {
            var instrumentTable = await _context.InstrumentTables.FindAsync(id);

            if (instrumentTable == null)
            {
                return NotFound();
            }

            return instrumentTable;
        }

        // PUT: api/InstrumentTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrumentTable(int id, InstrumentTable instrumentTable)
        {
            if (id != instrumentTable.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(instrumentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentTableExists(id))
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

        // POST: api/InstrumentTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstrumentTable>> PostInstrumentTable(InstrumentTable instrumentTable)
        {
            _context.InstrumentTables.Add(instrumentTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InstrumentTableExists(instrumentTable.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInstrumentTable", new { id = instrumentTable.ProductId }, instrumentTable);
        }

        // DELETE: api/InstrumentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrumentTable(int id)
        {
            var instrumentTable = await _context.InstrumentTables.FindAsync(id);
            if (instrumentTable == null)
            {
                return NotFound();
            }

            _context.InstrumentTables.Remove(instrumentTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstrumentTableExists(int id)
        {
            return _context.InstrumentTables.Any(e => e.ProductId == id);
        }
    }
}
