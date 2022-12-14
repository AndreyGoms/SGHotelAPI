using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGHotelAPI.Model;

namespace SGHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartosController : ControllerBase
    {
        private readonly SGHotelContext _context;

        public QuartosController(SGHotelContext context)
        {
            _context = context;
        }

        // GET: api/Quartos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuartos()
        {
            return await _context.Quartos.ToListAsync();
        }

        // GET: api/Quartos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quarto>> GetQuarto(int id)
        {
            var quarto = await _context.Quartos.FindAsync(id);

            if (quarto == null)
            {
                return NotFound();
            }

            return quarto;
        }

        // PUT: api/Quartos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuarto(int id, Quarto quarto)
        {
            if (id != quarto.idQuarto)
            {
                return BadRequest();
            }

            _context.Entry(quarto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuartoExists(id))
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

        // POST: api/Quartos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
        {
            var verificaAndar = _context.Andares.Where(andar => andar.idAndar == quarto.idAndar);

            if(!verificaAndar.Any())
                return NotFound("Andar inexistente!");

            _context.Quartos.Add(quarto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuarto", new { id = quarto.idQuarto }, quarto);
        }

        // DELETE: api/Quartos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuarto(int id)
        {
            var quarto = await _context.Quartos.FindAsync(id);
            if (quarto == null)
            {
                return NotFound();
            }

            _context.Quartos.Remove(quarto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuartoExists(int id)
        {
            return _context.Quartos.Any(e => e.idQuarto == id);
        }
    }
}
