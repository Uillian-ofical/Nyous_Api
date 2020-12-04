using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nyous.Contexts;
using Nyous.Domains;

namespace Nyous.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private readonly NyousContext _context = new NyousContext();

        // GET: api/Localizacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localizacao>>> GetLocalizacao()
        {
            return await _context.Localizacao.ToListAsync();
        }

        // GET: api/Localizacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localizacao>> GetLocalizacao(int id)
        {
            var localizacao = await _context.Localizacao.FindAsync(id);

            if (localizacao == null)
            {
                return NotFound();
            }

            return localizacao;
        }

        // PUT: api/Localizacao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalizacao(int id, Localizacao localizacao)
        {
            if (id != localizacao.IdLocalizacao)
            {
                return BadRequest();
            }

            _context.Entry(localizacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalizacaoExists(id))
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

        // POST: api/Localizacao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Localizacao>> PostLocalizacao(Localizacao localizacao)
        {
            _context.Localizacao.Add(localizacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalizacao", new { id = localizacao.IdLocalizacao }, localizacao);
        }

        // DELETE: api/Localizacao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Localizacao>> DeleteLocalizacao(int id)
        {
            var localizacao = await _context.Localizacao.FindAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }

            _context.Localizacao.Remove(localizacao);
            await _context.SaveChangesAsync();

            return localizacao;
        }

        private bool LocalizacaoExists(int id)
        {
            return _context.Localizacao.Any(e => e.IdLocalizacao == id);
        }
    }
}
