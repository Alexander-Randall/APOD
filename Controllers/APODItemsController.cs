using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APOD.Models;

namespace APOD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APODItemsController : ControllerBase
    {
        private readonly APODContext _context;

        public APODItemsController(APODContext context)
        {
            _context = context;
        }

        // GET: api/APODItems 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APODItem>>> GetAPODItems()
        {
            return await _context.APODItems.ToListAsync();
        }

        // GET: api/APODItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APODItem>> GetAPODItem(long id)
        {
            var aPODItem = await _context.APODItems.FindAsync(id);

            if (aPODItem == null)
            {
                return NotFound();
            }

            return aPODItem;
        }

        // PUT: api/APODItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPODItem(long id, APODItem aPODItem)
        {
            if (id != aPODItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(aPODItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APODItemExists(id))
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

        // POST: api/APODItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<APODItem>> PostAPODItem(APODItem aPODItem)
        {
            _context.APODItems.Add(aPODItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAPODItem), new { id = aPODItem.Id }, aPODItem);
        }

        // DELETE: api/APODItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<APODItem>> DeleteAPODItem(long id)
        {
            var aPODItem = await _context.APODItems.FindAsync(id);
            if (aPODItem == null)
            {
                return NotFound();
            }

            _context.APODItems.Remove(aPODItem);
            await _context.SaveChangesAsync();

            return aPODItem;
        }

        private bool APODItemExists(long id)
        {
            return _context.APODItems.Any(e => e.Id == id);
        }
    }
}
