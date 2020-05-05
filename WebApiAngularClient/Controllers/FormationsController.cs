using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAngularClient.Models;

namespace WebApiAngularClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormationsController : ControllerBase
    {
        private readonly AvisFormationsDBContext _context;

        public FormationsController(AvisFormationsDBContext context)
        {
            _context = context;
        }

        // GET: api/Formations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formation>>> GetFormation()
        {
            return await _context.Formation.ToListAsync();
        }

        // GET: api/Formations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Formation>> GetFormation(int id)
        {
            var formation = await _context.Formation.FindAsync(id);

            if (formation == null)
            {
                return NotFound();
            }

            return formation;
        }

        // PUT: api/Formations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormation(int id, Formation formation)
        {
            if (id != formation.Id)
            {
                return BadRequest();
            }

            _context.Entry(formation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormationExists(id))
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

        // POST: api/Formations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Formation>> PostFormation(Formation formation)
        {
            _context.Formation.Add(formation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormation", new { id = formation.Id }, formation);
        }

        // DELETE: api/Formations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Formation>> DeleteFormation(int id)
        {
            var formation = await _context.Formation.FindAsync(id);
            if (formation == null)
            {
                return NotFound();
            }

            _context.Formation.Remove(formation);
            await _context.SaveChangesAsync();

            return formation;
        }

        private bool FormationExists(int id)
        {
            return _context.Formation.Any(e => e.Id == id);
        }
    }
}
