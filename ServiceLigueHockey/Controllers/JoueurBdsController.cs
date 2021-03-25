using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data;
using ServiceLigueHockey.Models;
using ServiceLigueHockey.Models.Dto;

namespace ServiceLigueHockey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoueurBdsController : ControllerBase
    {
        private readonly ServiceLigueHockeyContext _context;

        public JoueurBdsController(ServiceLigueHockeyContext context)
        {
            _context = context;
        }

        // GET: api/JoueurBds
        [HttpGet]
        public IQueryable<JoueurDto> GetJoueurBd()
        {
            var listeJoueur = from joueur in _context.Joueur
                              select new JoueurDto
                              {
                                  No_Joueur = joueur.No_Joueur,
                                  Prenom = joueur.Prenom,
                                  Nom = joueur.Nom,
                                  ville_naissance = joueur.Ville_naissance,
                                  pays_origine = joueur.Pays_origine,
                                  Date_Naissance = joueur.Date_Naissance
                              };
            return listeJoueur;
        }

        // GET: api/JoueurBds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JoueurDto>> GetJoueurBd(int id)
        {
            var joueurBd = await _context.Joueur.FindAsync(id);

            if (joueurBd == null)
            {
                return NotFound();
            }

            var joueurDto = new JoueurDto
            {
                No_Joueur = joueurBd.No_Joueur,
                Prenom = joueurBd.Prenom,
                Nom = joueurBd.Nom,
                ville_naissance = joueurBd.Ville_naissance,
                pays_origine = joueurBd.Pays_origine,
                Date_Naissance = joueurBd.Date_Naissance
            };

            return Ok(joueurDto);
        }

        // PUT: api/JoueurBds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoueurBd(int id, JoueurBd joueurBd)
        {
            if (id != joueurBd.No_Joueur)
            {
                return BadRequest();
            }

            _context.Entry(joueurBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueurBdExists(id))
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

        // POST: api/JoueurBds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JoueurBd>> PostJoueurBd(JoueurBd joueurBd)
        {
            _context.Joueur.Add(joueurBd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoueurBd", new { id = joueurBd.No_Joueur }, joueurBd);
        }

        // DELETE: api/JoueurBds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoueurBd(int id)
        {
            var joueurBd = await _context.Joueur.FindAsync(id);
            if (joueurBd == null)
            {
                return NotFound();
            }

            _context.Joueur.Remove(joueurBd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JoueurBdExists(int id)
        {
            return _context.Joueur.Any(e => e.No_Joueur == id);
        }
    }
}
