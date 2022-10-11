using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Opdracht6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractieController : ControllerBase
    {
        private readonly PretparkContext _context;

        public AttractieController(PretparkContext context)
        {
            _context = context;
        }

        // GET: api/Attractie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StripedAttractie>>> GetAttractie()
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attracties = await _context.Attractie.ToListAsync();

            List<StripedAttractie> attractiesToSend = new List<StripedAttractie>();
            for (int i = 0; i < attracties.Count(); i++)
            {
                attractiesToSend.Add(new StripedAttractie{Id = attracties[i].Id, Naam = attracties[i].Naam, Engheid = attracties[i].Engheid, Bouwjaar = attracties[i].Bouwjaar, AantalLikes = attracties[i].aantalLikes});
            }

            return attractiesToSend;
        }

        // GET: api/Attractie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StripedAttractie>> GetAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attractie = await _context.Attractie.FindAsync(id);

            if (attractie == null)
            {
                return NotFound();
            }

            var attractieToSend = new StripedAttractie{Id = attractie.Id, Naam = attractie.Naam, Engheid = attractie.Engheid, Bouwjaar = attractie.Bouwjaar, AantalLikes = attractie.aantalLikes};

            return attractieToSend;
        }

        // GET: api/Attractie/ByYear
        [HttpGet]
        [Route("ByYear")]
        public async Task<ActionResult<IEnumerable<StripedAttractie>>> OrderAttractieByYear()
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attracties = await _context.Attractie.OrderBy(at => at.Bouwjaar).ToListAsync();
            
            List<StripedAttractie> attractiesToSend = new List<StripedAttractie>();
            for (int i = 0; i < attracties.Count(); i++)
            {
                attractiesToSend.Add(new StripedAttractie{Id = attracties[i].Id, Naam = attracties[i].Naam, Engheid = attracties[i].Engheid, Bouwjaar = attracties[i].Bouwjaar, AantalLikes = attracties[i].aantalLikes});
            }

            return attractiesToSend;
        }

        // PUT: api/Attractie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Medewerker")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttractie(int id, Attractie attractie)
        {
            if (id != attractie.Id)
            {
                return BadRequest();
            }

            _context.Entry(attractie).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractieExists(id))
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

        // POST: api/Attractie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Medewerker")]
        [HttpPost]
        public async Task<ActionResult<Attractie>> PostAttractie(Attractie attractie)
        {
          if (_context.Attractie == null)
          {
              return Problem("Entity set 'PretparkContext.Attractie'  is null.");
          }
            _context.Attractie.Add(attractie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttractie", new { id = attractie.Id }, attractie);
        }

        // DELETE: api/Attractie/5
        [Authorize(Roles = "Medewerker")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attractie = await _context.Attractie.FindAsync(id);
            if (attractie == null)
            {
                return NotFound();
            }

            _context.Attractie.Remove(attractie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "Gast")]
        [HttpPost("{id}")]
        [Route("Like")]
        public async Task<IActionResult> LikeAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }

            var attractie = await _context.Attractie.FindAsync(id);

      	    if (attractie == null)
            {
                return NotFound();
            }

            Request.Headers.TryGetValue("Authorization", out var headervalue);
            string cleanToken = headervalue.ToString().Substring(7);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(cleanToken);
            var tokenS = jsonToken as JwtSecurityToken;
            string[] loggedInUserDisgusting = tokenS.Claims.ToList()[0].ToString().Split(": ");
            string loggedInUser = loggedInUserDisgusting[1];
            
            // moet op een of ander manier bij de gebruiker tabel komen en er een op naam uithalen
            var user = _context.Gebruiker.FirstAsync

            if(attractie.gebruikerLikes.Count() != null)
            {
                for (int i = 0; i < attractie.gebruikerLikes.Count(); i++)
                {
                    if(attractie.gebruikerLikes[i].UserName == loggedInUser)
                    {
                        return BadRequest();
                    }
                }
            }
                
            attractie.gebruikerLikes.Add()

            _context.Entry(attractie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(201);
        }

        private bool AttractieExists(int id)
        {
            return (_context.Attractie?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
