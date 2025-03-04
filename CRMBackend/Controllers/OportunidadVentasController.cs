using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRMBackend.Data;
using CRMControllers.Entidades;

namespace CRMBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OportunidadVentasController : ControllerBase
    {
        private readonly DataContext _context;

        public OportunidadVentasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OportunidadVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OportunidadVenta>>> GetOportunidadVenta()
        {
            return await _context.OportunidadVenta.ToListAsync();
        }

        // GET: api/OportunidadVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OportunidadVenta>> GetOportunidadVenta(int id)
        {
            var oportunidadVenta = await _context.OportunidadVenta.FindAsync(id);

            if (oportunidadVenta == null)
            {
                return NotFound();
            }

            return oportunidadVenta;
        }

        // PUT: api/OportunidadVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOportunidadVenta(int id, OportunidadVenta oportunidadVenta)
        {
            if (id != oportunidadVenta.OportunidadID)
            {
                return BadRequest();
            }

            _context.Entry(oportunidadVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OportunidadVentaExists(id))
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

        // POST: api/OportunidadVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OportunidadVenta>> PostOportunidadVenta(OportunidadVenta oportunidadVenta)
        {
            _context.OportunidadVenta.Add(oportunidadVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOportunidadVenta", new { id = oportunidadVenta.OportunidadID }, oportunidadVenta);
        }

        // DELETE: api/OportunidadVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOportunidadVenta(int id)
        {
            var oportunidadVenta = await _context.OportunidadVenta.FindAsync(id);
            if (oportunidadVenta == null)
            {
                return NotFound();
            }

            _context.OportunidadVenta.Remove(oportunidadVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OportunidadVentaExists(int id)
        {
            return _context.OportunidadVenta.Any(e => e.OportunidadID == id);
        }
    }
}
