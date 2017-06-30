using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaApi.DAL;
using TareaApi.Models;

namespace TareaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cobros")]
    public class CobrosController : Controller
    {
        private readonly CobrosDb _context;

        public CobrosController(CobrosDb context)
        {
            _context = context;
        }

        // GET: api/Cobros
        [HttpGet]
        public IEnumerable<Cobros> GetCobros()
        {
            return _context.Cobros;
        }

        // GET: api/Cobros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCobros([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cobros = await _context.Cobros.SingleOrDefaultAsync(m => m.IdCobro == id);

            if (cobros == null)
            {
                return NotFound();
            }

            return Ok(cobros);
        }

        // PUT: api/Cobros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobros([FromRoute] int id, [FromBody] Cobros cobros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cobros.IdCobro)
            {
                return BadRequest();
            }

            _context.Entry(cobros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobrosExists(id))
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

        // POST: api/Cobros
        [HttpPost]
        public async Task<IActionResult> PostCobros([FromBody] Cobros cobros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cobros.Add(cobros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCobros", new { id = cobros.IdCobro }, cobros);
        }

        // DELETE: api/Cobros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobros([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cobros = await _context.Cobros.SingleOrDefaultAsync(m => m.IdCobro == id);
            if (cobros == null)
            {
                return NotFound();
            }

            _context.Cobros.Remove(cobros);
            await _context.SaveChangesAsync();

            return Ok(cobros);
        }

        private bool CobrosExists(int id)
        {
            return _context.Cobros.Any(e => e.IdCobro == id);
        }
    }
}