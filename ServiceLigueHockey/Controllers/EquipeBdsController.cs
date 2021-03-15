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
    public class EquipeBdsController : ControllerBase
    {
        private readonly ServiceLigueHockeyContext _context;

        public EquipeBdsController(ServiceLigueHockeyContext context)
        {
            _context = context;
        }

        // GET: api/EquipeBds
        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<EquipeBd>>> GetEquipeBd()
        {
            return await _context.EquipeBd.ToListAsync();
        }*/
        public IQueryable<EquipeDto> GetEquipeDto()
        {
            var listeEquipe = from equipe in _context.Equipe
                              select new EquipeDto
                              {
                                  No_Equipe = equipe.No_Equipe,
                                  Nom_Equipe = equipe.Nom_Equipe,
                                  Ville = equipe.Ville,
                                  Annee_debut = equipe.Annee_debut,
                                  Annee_fin = equipe.Annee_fin,
                                  Est_Devenue_Equipe = equipe.Est_Devenue_Equipe
                              };
            return listeEquipe;
        }

        // GET: api/EquipeBds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipeDto>> GetEquipeDto(int id)
        {
            var equipeBd = await _context.Equipe.FindAsync(id);

            if (equipeBd == null)
            {
                return NotFound();
            }

            var equipeDto = new EquipeDto
            {
                No_Equipe = equipeBd.No_Equipe,
                Nom_Equipe = equipeBd.Nom_Equipe,
                Ville = equipeBd.Ville,
                Annee_debut = equipeBd.Annee_debut,
                Annee_fin = equipeBd.Annee_fin,
                Est_Devenue_Equipe = equipeBd.Est_Devenue_Equipe
            };

            return Ok(equipeDto);
        }

        // PUT: api/EquipeBds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipeBd(int id, EquipBd equipeBd)
        {
            if (id != equipeBd.No_Equipe)
            {
                return BadRequest();
            }

            _context.Entry(equipeBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeBdExists(id))
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

        // POST: api/EquipeBds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        /*public async Task<ActionResult<EquipeBd>> PostEquipeBd(EquipeBd equipeBd)
        {
            _context.EquipeBd.Add(equipeBd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipeBd", new { id = equipeBd.No_Equipe }, equipeBd);
        }*/
        public async Task<ActionResult<EquipBd>> PostEquipeDto(EquipeDto equipe)
        {
            var equipeBd = new EquipBd
            {
                No_Equipe = equipe.No_Equipe,
                Nom_Equipe = equipe.Nom_Equipe,
                Ville = equipe.Ville,
                Annee_debut = equipe.Annee_debut,
                Annee_fin = equipe.Annee_fin,
                Est_Devenue_Equipe = equipe.Est_Devenue_Equipe
            };

            _context.Equipe.Add(equipeBd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipeDto", new { id = equipeBd.No_Equipe }, equipe);
        }

        // DELETE: api/EquipeBds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipeBd(int id)
        {
            var equipeBd = await _context.Equipe.FindAsync(id);
            if (equipeBd == null)
            {
                return NotFound();
            }

            _context.Equipe.Remove(equipeBd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipeBdExists(int id)
        {
            return _context.Equipe.Any(e => e.No_Equipe == id);
        }
    }
}
