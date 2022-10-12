using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

namespace Opdracht6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractieController : ControllerBase
    {
        private readonly PretparkContext _context;
        private readonly UserManager<Gebruiker> _userManager;

        public AttractieController(UserManager<Gebruiker> userManager, PretparkContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: api/Attractie/Get
        [HttpGet]
        [Authorize(Roles = "Gast")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<StripedAttractie>>> GetAttractie()
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attracties = await Task.Run(() => _context.Attractie.Include(at => at.gebruikerLikes).ToListAsync());

            List<StripedAttractie> attractiesToSend = new List<StripedAttractie>();
            for (int i = 0; i < attracties.Count(); i++)
            {
                attractiesToSend.Add(new StripedAttractie{Id = attracties[i].Id, Naam = attracties[i].Naam, Engheid = attracties[i].Engheid, Bouwjaar = attracties[i].Bouwjaar, AantalLikes = attracties[i].aantalLikes});
            }

            return attractiesToSend;
        }

        // GET: api/Attractie/Get/5
        [HttpGet("Get/{id}")]
        [Authorize(Roles = "Gast")]
        public async Task<ActionResult<StripedAttractie>> GetAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attracties = await Task.Run(() => _context.Attractie.Include(at => at.gebruikerLikes).ToListAsync());
            var attractie = attracties.Where(at => at.Id == id).FirstOrDefault();

            if (attractie == null)
            {
                return NotFound();
            }

            var attractieToSend = new StripedAttractie{Id = attractie.Id, Naam = attractie.Naam, Engheid = attractie.Engheid, Bouwjaar = attractie.Bouwjaar, AantalLikes = attractie.aantalLikes};
            return attractieToSend;
        }

        // GET: api/Attractie/Get/ByYear
        [HttpGet]
        [Route("Get/ByYear")]
        [Authorize(Roles = "Gast")]
        public async Task<ActionResult<IEnumerable<StripedAttractie>>> OrderAttractieByYear()
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }

            var attracties = await Task.Run(() => _context.Attractie.Include(at => at.gebruikerLikes).OrderBy(at => at.Bouwjaar).ToListAsync());
            
            List<StripedAttractie> attractiesToSend = new List<StripedAttractie>();
            for (int i = 0; i < attracties.Count(); i++)
            {
                attractiesToSend.Add(new StripedAttractie{Id = attracties[i].Id, Naam = attracties[i].Naam, Engheid = attracties[i].Engheid, Bouwjaar = attracties[i].Bouwjaar, AantalLikes = attracties[i].aantalLikes});
            }

            return attractiesToSend;
        }

        // GET: api/Attractie/GetMW
        [HttpGet]
        [Authorize(Roles = "Medewerker")]
        [Route("GetMW")]
        public async Task<ActionResult<IEnumerable<Attractie>>> GetAttractieMW()
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attracties = await Task.Run(() => _context.Attractie.Include(at => at.gebruikerLikes).ToListAsync());

            return attracties;
        }

        // GET: api/Attractie/GetMW/5
        [HttpGet("GetMW/{id}")]
        [Authorize(Roles = "Medewerker")]
        public async Task<ActionResult<Attractie>> GetAttractieMW(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attracties = await Task.Run(() => _context.Attractie.Include(at => at.gebruikerLikes).ToListAsync());
            var attractie = attracties.Where(at => at.Id == id).FirstOrDefault();

            if (attractie == null)
            {
                return NotFound();
            }

            return attractie;
        }

        // GET: api/Attractie/GetMW/ByYear
        [HttpGet]
        [Route("GetMW/ByYear")]
        [Authorize(Roles = "Medewerker")]
        public async Task<ActionResult<IEnumerable<Attractie>>> OrderAttractieByYearMW()
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }

            var attracties = await Task.Run(() => _context.Attractie.Include(at => at.gebruikerLikes).OrderBy(at => at.Bouwjaar).ToListAsync());

            return attracties;
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
        [HttpPut("Like/{id}")]
        public async Task<IActionResult> LikeAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }

            var attracties = await Task.Run(() => _context.Attractie.Include(at => at.gebruikerLikes).ToListAsync());
            var attractie = attracties.Where(at => at.Id == id).FirstOrDefault();
           
            Console.WriteLine(attractie.Naam);

            Console.WriteLine("hallo: " + id);
      	    if (attractie == null)
            {
                return NotFound();
            }

            string loggedInUser = getValueFromHeader(0);

            var user = await _userManager.FindByNameAsync(loggedInUser);
            var realUser = await _context.Gebruiker.FindAsync(user.Id);
            if(realUser == null)
            {
                return BadRequest();
            }

            if(attractie.gebruikerLikes != null && attractie.gebruikerLikes.Count() != 0)
            {
                for (int i = 0; i < attractie.gebruikerLikes.Count(); i++)
                {
                    if(attractie.gebruikerLikes[i].UserName == loggedInUser)
                    {
                        return BadRequest();
                    }
                }
            }
            
            realUser.gelikedeAttracties.Add(attractie);
            attractie.gebruikerLikes.Add(realUser);

            _context.Entry(realUser).State = EntityState.Modified;
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

        public string getValueFromHeader(int property) 
        {
            Request.Headers.TryGetValue("Authorization", out var headervalue);
            string cleanToken = headervalue.ToString().Substring(7);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(cleanToken);
            var tokenS = jsonToken as JwtSecurityToken;
            string[] loggedInUserDisgusting = tokenS.Claims.ToList()[property].ToString().Split(": ");
            string loggedInUser = loggedInUserDisgusting[1];
            return loggedInUser;
        }
    }
}
