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
    public class AddtocartsController : ControllerBase
    {
        private readonly AddToCartContext _context;

        public AddtocartsController(AddToCartContext context)
        {
            _context = context;
        }

        // GET: api/Addtocarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Addtocart>>> GetAddtocarts()
        {
            return await _context.Addtocarts.ToListAsync();
        }

        // GET: api/Addtocarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Addtocart>> GetAddtocart(int id)
        {
            var addtocart = await _context.Addtocarts.FindAsync(id);

            if (addtocart == null)
            {
                return NotFound();
            }

            return addtocart;
        }

        // PUT: api/Addtocarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddtocart(int id, Addtocart addtocart)
        {
            if (id != addtocart.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(addtocart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddtocartExists(id))
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

        // POST: api/Addtocarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Addtocart>> PostAddtocart(Addtocart addtocart)
        {
            _context.Addtocarts.Add(addtocart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AddtocartExists(addtocart.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAddtocart", new { id = addtocart.ProductId }, addtocart);
        }

        // DELETE: api/Addtocarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddtocart(int id)
        {
            var addtocart = await _context.Addtocarts.FindAsync(id);
            if (addtocart == null)
            {
                return NotFound();
            }

            _context.Addtocarts.Remove(addtocart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddtocartExists(int id)
        {
            return _context.Addtocarts.Any(e => e.ProductId == id);
        }
    }
}
