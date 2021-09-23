using System.Collections.Generic;
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
    public class StatsJoueurBdsController : ControllerBase
    {
        private readonly ServiceLigueHockeyContext _context;

        public StatsJoueurBdsController(ServiceLigueHockeyContext context)
        {
            _context = context;
        }

        // GET: api/StatsJoueurBds/parannee/2020
        [HttpGet("parannee/{annee}")]
        public ActionResult<IEnumerable<StatsJoueurDto>> GetStatsJoueurBd(short annee)
        {
            var listeStats = _context.StatsJoueurBd
                .Where(x => x.AnneeStats == annee)
                .OrderByDescending(x => x.NbPoints)
                .Select(item => new StatsJoueurDto
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
                });

            return Ok(listeStats.ToList());
        }

        // GET: api/StatsJoueurBds/5/2020
        [HttpGet("{noJoueur}/{anneeStats}")]
        public ActionResult<StatsJoueurDto> GetStatsJoueurBd(int noJoueur, short anneeStats)
        {
            var retour = _context.StatsJoueurBd
                .Where(x => x.No_JoueurRefId == noJoueur && x.AnneeStats == anneeStats)
                .Select(statsJoueurBd => new StatsJoueurDto
                {
                    No_JoueurRefId = statsJoueurBd.No_JoueurRefId,
                    AnneeStats = statsJoueurBd.AnneeStats,
                    NbPartiesJouees = statsJoueurBd.NbPartiesJouees,
                    NbButs = statsJoueurBd.NbButs,
                    NbPasses = statsJoueurBd.NbPasses,
                    NbPoints = statsJoueurBd.NbPoints,
                    NbMinutesPenalites = statsJoueurBd.NbMinutesPenalites,
                    PlusseMoins = statsJoueurBd.PlusseMoins,
                    Victoires = statsJoueurBd.Victoires,
                    Defaites = statsJoueurBd.Defaites,
                    DefaitesEnProlongation = statsJoueurBd.DefaitesEnProlongation,
                    Nulles = statsJoueurBd.Nulles,
                    MinutesJouees = statsJoueurBd.MinutesJouees,
                    ButsAlloues = statsJoueurBd.ButsAlloues,
                    TirsAlloues = statsJoueurBd.TirsAlloues,
                    Joueur = new JoueurDto
                    {
                        No_Joueur = statsJoueurBd.Joueur.No_Joueur,
                        Prenom = statsJoueurBd.Joueur.Prenom,
                        Nom = statsJoueurBd.Joueur.Nom,
                        ville_naissance = statsJoueurBd.Joueur.Ville_naissance,
                        pays_origine = statsJoueurBd.Joueur.Pays_origine,
                        Date_Naissance = statsJoueurBd.Joueur.Date_Naissance
                    }
                }).FirstOrDefault();

            if (retour == null)
            {
                return NotFound();
            }

            return Ok(retour);
        }

        // PUT: api/StatsJoueurBds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/{annee}")]
        public async Task<IActionResult> PutStatsJoueurBd(int id, short annee, StatsJoueurDto statsJoueurDto)
        {
            if (id != statsJoueurDto.No_JoueurRefId && annee != statsJoueurDto.AnneeStats)
            {
                return BadRequest();
            }

            var statsJoueurBd = new StatsJoueurBd
            {
                No_JoueurRefId = statsJoueurDto.No_JoueurRefId,
                AnneeStats = statsJoueurDto.AnneeStats,
                NbPartiesJouees = statsJoueurDto.NbPartiesJouees,
                NbButs = statsJoueurDto.NbButs,
                NbPasses = statsJoueurDto.NbPasses,
                NbPoints = statsJoueurDto.NbPoints,
                NbMinutesPenalites = statsJoueurDto.NbMinutesPenalites,
                PlusseMoins = statsJoueurDto.PlusseMoins,
                Victoires = statsJoueurDto.Victoires,
                Defaites = statsJoueurDto.Defaites,
                DefaitesEnProlongation = statsJoueurDto.DefaitesEnProlongation,
                Nulles = statsJoueurDto.Nulles,
                MinutesJouees = statsJoueurDto.MinutesJouees,
                ButsAlloues = statsJoueurDto.ButsAlloues,
                TirsAlloues = statsJoueurDto.TirsAlloues,
                Joueur = new JoueurBd
                {
                    No_Joueur = statsJoueurDto.Joueur.No_Joueur,
                    Prenom = statsJoueurDto.Joueur.Prenom,
                    Nom = statsJoueurDto.Joueur.Nom,
                    Ville_naissance = statsJoueurDto.Joueur.ville_naissance,
                    Pays_origine = statsJoueurDto.Joueur.pays_origine,
                    Date_Naissance = statsJoueurDto.Joueur.Date_Naissance
                }
            };

            _context.Entry(statsJoueurBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatsJoueurBdExists(id, annee))
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
        public async Task<ActionResult<StatsJoueurDto>> PostStatsJoueurBd(StatsJoueurDto statsJoueurDto)
        {
            var joueurBd = new JoueurBd
            {
                No_Joueur = statsJoueurDto.Joueur.No_Joueur,
                Prenom = statsJoueurDto.Joueur.Prenom,
                Nom = statsJoueurDto.Joueur.Nom,
                Ville_naissance = statsJoueurDto.Joueur.ville_naissance,
                Pays_origine = statsJoueurDto.Joueur.pays_origine,
                Date_Naissance = statsJoueurDto.Joueur.Date_Naissance,
                listeStatsJoueur = new List<StatsJoueurBd>()
            };

            var statsJoueurBd = new StatsJoueurBd
            {
                No_JoueurRefId = statsJoueurDto.No_JoueurRefId,
                AnneeStats = statsJoueurDto.AnneeStats,
                NbPartiesJouees = statsJoueurDto.NbPartiesJouees,
                NbButs = statsJoueurDto.NbButs,
                NbPasses = statsJoueurDto.NbPasses,
                NbPoints = statsJoueurDto.NbPoints,
                NbMinutesPenalites = statsJoueurDto.NbMinutesPenalites,
                PlusseMoins = statsJoueurDto.PlusseMoins,
                Victoires = statsJoueurDto.Victoires,
                Defaites = statsJoueurDto.Defaites,
                DefaitesEnProlongation = statsJoueurDto.DefaitesEnProlongation,
                Nulles = statsJoueurDto.Nulles,
                MinutesJouees = statsJoueurDto.MinutesJouees,
                ButsAlloues = statsJoueurDto.ButsAlloues,
                TirsAlloues = statsJoueurDto.TirsAlloues,
                Joueur = new JoueurBd
                {
                    No_Joueur = statsJoueurDto.Joueur.No_Joueur,
                    Prenom = statsJoueurDto.Joueur.Prenom,
                    Nom = statsJoueurDto.Joueur.Nom,
                    Ville_naissance = statsJoueurDto.Joueur.ville_naissance,
                    Pays_origine = statsJoueurDto.Joueur.pays_origine,
                    Date_Naissance = statsJoueurDto.Joueur.Date_Naissance
                }
            };

            _context.Joueur.Attach(statsJoueurBd.Joueur);
            _context.StatsJoueurBd.Add(statsJoueurBd);
            joueurBd.listeStatsJoueur.Add(statsJoueurBd);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (StatsJoueurBdExists(statsJoueurBd.No_JoueurRefId, statsJoueurBd.AnneeStats))
                {
                    return Conflict(ex);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostStatsJoueurBd", statsJoueurDto);
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

        private bool StatsJoueurBdExists(int id, short annee)
        {
            return _context.StatsJoueurBd.Any(e => e.No_JoueurRefId == id && e.AnneeStats == annee);
        }
    }
}
