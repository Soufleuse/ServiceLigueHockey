using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data;
using ServiceLigueHockey.Models;
using ServiceLigueHockey.Models.Dto;

namespace ServiceLigueHockey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsJoueurBdsController : ControllerBase
    {
        private readonly ServiceLigueHockeyContext _context;

        public StatsJoueurBdsController(ServiceLigueHockeyContext context)
        {
            _context = context;
        }

        // GET: api/StatsJoueurBds/annee/5
        [HttpGet("parannee/{annee}")]
        public ActionResult<IEnumerable<StatsJoueurDto>> GetStatsJoueurBd(short annee)
        {
            var listeStats = from item in _context.StatsJoueurBd
                             where item.AnneeStats == annee
                             orderby item.NbPoints descending
                             select new StatsJoueurDto
                             {
                                 No_JoueurRefId = item.No_JoueurRefId,
                                 AnneeStats = item.AnneeStats,
                                 NbPartiesJouees = item.NbPartiesJouees,
                                 NbButs = item.NbButs,
                                 NbPasses = item.NbPasses,
                                 NbPoints = item.NbPoints,
                                 NbMinutesPenalites = item.NbMinutesPenalites,
                                 PlusseMoins = item.PlusseMoins,
                                 MinutesJouees = item.MinutesJouees,
                                 Victoires = item.Victoires,
                                 Defaites = item.Defaites,
                                 DefaitesEnProlongation = item.DefaitesEnProlongation,
                                 Nulles = item.Nulles,
                                 ButsAlloues = item.ButsAlloues,
                                 TirsAlloues = item.TirsAlloues,
                                 Joueur = new JoueurDto
                                 {
                                     No_Joueur = item.Joueur.No_Joueur,
                                     Prenom = item.Joueur.Prenom,
                                     Nom = item.Joueur.Nom,
                                     ville_naissance = item.Joueur.Ville_naissance,
                                     pays_origine = item.Joueur.Pays_origine,
                                     Date_Naissance = item.Joueur.Date_Naissance
                                 }
                             };

            return Ok(listeStats.ToList());
        }

        // GET: api/StatsJoueurBds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatsJoueurBd>> GetStatsJoueurBd(int id)
        {
            var statsJoueurBd = await _context.StatsJoueurBd.FindAsync(id);

            if (statsJoueurBd == null)
            {
                return NotFound();
            }

            return statsJoueurBd;
        }

        // PUT: api/StatsJoueurBds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatsJoueurBd(int id, StatsJoueurBd statsJoueurBd)
        {
            if (id != statsJoueurBd.No_JoueurRefId)
            {
                return BadRequest();
            }

            _context.Entry(statsJoueurBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatsJoueurBdExists(id))
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

        // POST: api/StatsJoueurBds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatsJoueurBd>> PostStatsJoueurBd(StatsJoueurBd statsJoueurBd)
        {
            _context.StatsJoueurBd.Add(statsJoueurBd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatsJoueurBdExists(statsJoueurBd.No_JoueurRefId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStatsJoueurBd", new { id = statsJoueurBd.No_JoueurRefId }, statsJoueurBd);
        }

        // DELETE: api/StatsJoueurBds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatsJoueurBd(int id)
        {
            var statsJoueurBd = await _context.StatsJoueurBd.FindAsync(id);
            if (statsJoueurBd == null)
            {
                return NotFound();
            }

            _context.StatsJoueurBd.Remove(statsJoueurBd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatsJoueurBdExists(int id)
        {
            return _context.StatsJoueurBd.Any(e => e.No_JoueurRefId == id);
        }
    }
}
