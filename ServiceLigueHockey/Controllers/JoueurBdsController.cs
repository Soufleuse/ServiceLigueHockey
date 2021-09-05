using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data;
using ServiceLigueHockey.Models;
using ServiceLigueHockey.Models.Dto;

// Si jamais tu veux savoir c'est quoi la version de ton compilateur/ta version de C#, décomenter la prochaine ligne.
//#error version

namespace ServiceLigueHockey.Controllers
{
    /*
     * Controlleur pour JoueurBd
     */
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
        public ActionResult<IQueryable<JoueurDto>> GetJoueurBd()
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
            return Ok(listeJoueur);
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
        public async Task<ActionResult<JoueurDto>> PostJoueurDto(JoueurDto joueur)
        {
            var joueurBd = new JoueurBd
            {
                No_Joueur = joueur.No_Joueur,
                Prenom = joueur.Prenom,
                Nom = joueur.Nom,
                Date_Naissance = joueur.Date_Naissance,
                Ville_naissance = joueur.ville_naissance,
                Pays_origine = joueur.pays_origine
            };

            // Si je veux ajouter des stats de joueur à zéro, je n'ai qu'à décommenter le bloc de code suivant.
            /*var statJoueurBd = new StatsJoueurBd
            {
                No_JoueurRefId = joueurBd.No_Joueur,
                AnneeStats = (short)DateTime.Now.Year,
                ButsAlloues = 0
            };

            joueurBd.listeStatsJoueur = new Collection<StatsJoueurBd>();
            joueurBd.listeStatsJoueur.Add(statJoueurBd);*/

            _context.Joueur.Add(joueurBd);
            await _context.SaveChangesAsync();

            joueur.No_Joueur = joueurBd.No_Joueur;

            return CreatedAtAction("PostJoueurDto", joueur);
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
