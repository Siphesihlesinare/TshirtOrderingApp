using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TshirtWebApp.Models;

namespace TshirtWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeesController : ControllerBase
    {
        private readonly TeesContext _context;

        public TeesController(TeesContext context)
        {
            _context = context;
        }

        // GET: api/Tees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tee>>> GetTees()
        {
            return await _context.Tees.ToListAsync();
        }

        // GET: api/Tees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tee>> GetTee(int id)
        {
            var tee = await _context.Tees.FindAsync(id);

            if (tee == null)
            {
                return NotFound();
            }

            return tee;
        }

        // PUT: api/Tees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTee(int id, Tee tee)
        {
            if (id != tee.ID)
            {
                return BadRequest();
            }

            _context.Entry(tee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeeExists(id))
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

        // POST: api/Tees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tee>> PostTee(Tee tee)
        {
            _context.Tees.Add(tee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTee", new { id = tee.ID }, tee);
        }

        // DELETE: api/Tees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tee>> DeleteTee(int id)
        {
            var tee = await _context.Tees.FindAsync(id);
            if (tee == null)
            {
                return NotFound();
            }

            _context.Tees.Remove(tee);
            await _context.SaveChangesAsync();

            return tee;
        }

        private bool TeeExists(int id)
        {
            return _context.Tees.Any(e => e.ID == id);
        }
    }
}
