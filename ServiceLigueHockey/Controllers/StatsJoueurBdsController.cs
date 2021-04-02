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

        // GET: api/StatsJoueurBds
        [HttpGet]
        public ActionResult<IQueryable<StatsJoueurBd>> GetStatsJoueurBd()
        {
            var retour = from item in _context.StatsJoueurBd.OrderBy(x => x.NbPoints).Take(50)
                         select new StatsJoueurDto
                         {
                             No_JoueurRefId = item.No_JoueurRefId,
                             AnneeStats = item.AnneeStats,
                             NbPartiesJouees = item.NbPartiesJouees,
                             NbButs = item.NbButs,
                             NbPasses = item.NbPasses,
                             NbPoints = item.NbPoints,
                             PlusseMoins = item.PlusseMoins,
                             NbMinutesPenalites = item.NbMinutesPenalites,
                             MinutesJouees = item.MinutesJouees,
                             Victoires = item.Victoires,
                             Defaites = item.Defaites,
                             Nulles = item.Nulles,
                             DefaitesEnProlongation = item.DefaitesEnProlongation,
                             ButsAlloues = item.ButsAlloues,
                             TirsAlloues = item.TirsAlloues,
                             Joueur = new JoueurDto
                             {
                                 No_Joueur = item.Joueur.No_Joueur,
                                 Prenom = item.Joueur.Prenom,
                                 Nom = item.Joueur.Nom,
                                 Date_Naissance = item.Joueur.Date_Naissance,
                                 ville_naissance = item.Joueur.Ville_naissance,
                                 pays_origine = item.Joueur.Pays_origine
                             }
                         };

            return Ok(_context.StatsJoueurBd.OrderBy(x => x.NbPoints).Take(50));
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

            var retour = new StatsJoueurDto
            {
                No_JoueurRefId = statsJoueurBd.No_JoueurRefId,
                AnneeStats = statsJoueurBd.AnneeStats,
                NbPartiesJouees = statsJoueurBd.NbPartiesJouees,
                NbButs = statsJoueurBd.NbButs,
                NbPasses = statsJoueurBd.NbPasses,
                NbPoints = statsJoueurBd.NbPoints,
                NbMinutesPenalites = statsJoueurBd.NbMinutesPenalites,
                MinutesJouees = statsJoueurBd.MinutesJouees,
                PlusseMoins = statsJoueurBd.PlusseMoins,
                Victoires = statsJoueurBd.Victoires,
                Defaites = statsJoueurBd.Defaites,
                DefaitesEnProlongation = statsJoueurBd.DefaitesEnProlongation,
                Nulles = statsJoueurBd.Nulles,
                ButsAlloues = statsJoueurBd.ButsAlloues,
                TirsAlloues = statsJoueurBd.TirsAlloues,
                Joueur = new JoueurDto
                {
                    No_Joueur = statsJoueurBd.Joueur.No_Joueur,
                    Prenom = statsJoueurBd.Joueur.Prenom,
                    Nom = statsJoueurBd.Joueur.Nom,
                    Date_Naissance = statsJoueurBd.Joueur.Date_Naissance,
                    ville_naissance = statsJoueurBd.Joueur.Ville_naissance,
                    pays_origine = statsJoueurBd.Joueur.Pays_origine
                }
            };

            return Ok(retour);
        }

        // PUT: api/StatsJoueurBds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatsJoueurBd(int id, StatsJoueurDto statsJoueurDto)
        {
            if (id != statsJoueurDto.No_JoueurRefId)
            {
                return BadRequest();
            }

            var statsJoueurBd = new StatsJoueurBd
            {
                No_JoueurRefId=statsJoueurDto.No_JoueurRefId,
                AnneeStats = statsJoueurDto.AnneeStats,
                NbPartiesJouees = statsJoueurDto.NbPartiesJouees,
                NbButs = statsJoueurDto.NbButs,
                NbPasses = statsJoueurDto.NbPasses,
                NbPoints = statsJoueurDto.NbPoints,
                NbMinutesPenalites = statsJoueurDto.NbMinutesPenalites,
                MinutesJouees = statsJoueurDto.MinutesJouees,
                PlusseMoins = statsJoueurDto.PlusseMoins,
                Victoires = statsJoueurDto.Victoires,
                Defaites = statsJoueurDto.Defaites,
                DefaitesEnProlongation = statsJoueurDto.DefaitesEnProlongation,
                Nulles = statsJoueurDto.Nulles,
                ButsAlloues = statsJoueurDto.ButsAlloues,
                TirsAlloues = statsJoueurDto.TirsAlloues,
                Joueur = new JoueurBd
                {
                    No_Joueur = statsJoueurDto.Joueur.No_Joueur,
                    Prenom = statsJoueurDto.Joueur.Prenom,
                    Nom = statsJoueurDto.Joueur.Nom,
                    Date_Naissance = statsJoueurDto.Joueur.Date_Naissance,
                    Ville_naissance = statsJoueurDto.Joueur.ville_naissance,
                    Pays_origine = statsJoueurDto.Joueur.pays_origine
                }
            };

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
        public async Task<ActionResult<StatsJoueurBd>> PostStatsJoueurBd(StatsJoueurDto statsJoueurDto)
        {
            var statsJoueurBd = new StatsJoueurBd
            {
                No_JoueurRefId = statsJoueurDto.No_JoueurRefId,
                AnneeStats = statsJoueurDto.AnneeStats,
                NbPartiesJouees = statsJoueurDto.NbPartiesJouees,
                NbButs = statsJoueurDto.NbButs,
                NbPasses = statsJoueurDto.NbPasses,
                NbPoints = statsJoueurDto.NbPoints,
                NbMinutesPenalites = statsJoueurDto.NbMinutesPenalites,
                MinutesJouees = statsJoueurDto.MinutesJouees,
                PlusseMoins = statsJoueurDto.PlusseMoins,
                Victoires = statsJoueurDto.Victoires,
                Defaites = statsJoueurDto.Defaites,
                DefaitesEnProlongation = statsJoueurDto.DefaitesEnProlongation,
                Nulles = statsJoueurDto.Nulles,
                ButsAlloues = statsJoueurDto.ButsAlloues,
                TirsAlloues = statsJoueurDto.TirsAlloues,
                Joueur = new JoueurBd
                {
                    No_Joueur = statsJoueurDto.Joueur.No_Joueur,
                    Prenom = statsJoueurDto.Joueur.Prenom,
                    Nom = statsJoueurDto.Joueur.Nom,
                    Date_Naissance = statsJoueurDto.Joueur.Date_Naissance,
                    Ville_naissance = statsJoueurDto.Joueur.ville_naissance,
                    Pays_origine = statsJoueurDto.Joueur.pays_origine
                }
            };

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
