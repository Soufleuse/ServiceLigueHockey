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
    public class equipe_joueurBdsController : ControllerBase
    {
        private readonly ServiceLigueHockeyContext _context;

        public equipe_joueurBdsController(ServiceLigueHockeyContext context)
        {
            _context = context;
        }

        // GET: api/equipe_joueurBds
        [HttpGet]
        public ActionResult<IList<equipe_joueurDto>> Getequipe_joueurBd()
        {
            var listeEquipeJoueur = from item in _context.equipe_joueur
                                    select new equipe_joueurDto
                                    {
                                        no_equipe = item.no_equipe,
                                        no_joueur = item.no_joueur,
                                        no_dossard = item.no_dossard,
                                        date_debut_avec_equipe = item.date_debut_avec_equipe,
                                        date_fin_avec_equipe = item.date_fin_avec_equipe
                                    };

            var retour = new List<equipe_joueurDto>();
            foreach (var item in listeEquipeJoueur)
            {
                var unJoueur = _context.Joueur.Find(item.no_joueur);

                retour.Add(new equipe_joueurDto
                {
                    no_equipe = item.no_equipe,
                    no_joueur = item.no_joueur,
                    no_dossard = item.no_dossard,
                    prenom_nom_joueur = unJoueur.Prenom + " " + unJoueur.Nom,
                    date_debut_avec_equipe = item.date_debut_avec_equipe,
                    date_fin_avec_equipe = item.date_fin_avec_equipe
                });
            }

            return Ok(retour);
        }

        // GET: api/equipe_joueurBds/5
        [HttpGet("{id}")]
        public ActionResult<equipe_joueurDto> Getequipe_joueurBd(int id)
        {
            var lecture = from item in _context.equipe_joueur
                             where item.no_equipe == id
                             select new equipe_joueurDto
                             {
                                 no_equipe = item.no_equipe,
                                 no_joueur = item.no_joueur,
                                 no_dossard = item.no_dossard,
                                 date_debut_avec_equipe = item.date_debut_avec_equipe,
                                 date_fin_avec_equipe = item.date_fin_avec_equipe
                             };

            if (lecture == null)
            {
                return NotFound();
            }

            var listeAlignement = new List<equipe_joueurDto>();
            foreach (var item in lecture)
            {
                var unJoueur = _context.Joueur.Find(item.no_joueur);
                listeAlignement.Add(new equipe_joueurDto
                {
                    no_equipe = item.no_equipe,
                    no_joueur = item.no_joueur,
                    no_dossard = item.no_dossard,
                    date_debut_avec_equipe = item.date_debut_avec_equipe,
                    date_fin_avec_equipe = item.date_fin_avec_equipe,
                    prenom_nom_joueur = unJoueur.Prenom + " " + unJoueur.Nom
                });
            }

            return Ok(listeAlignement);
        }

        // PUT: api/equipe_joueurBds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putequipe_joueurBd(int id, equipe_joueurDto equipe_joueurDto)
        {
            if (id != equipe_joueurDto.no_equipe)
            {
                return BadRequest();
            }

            var equipe_joueurBd = new equipe_joueurBd
            {
                no_equipe = equipe_joueurDto.no_equipe,
                no_joueur = equipe_joueurDto.no_joueur,
                no_dossard = equipe_joueurDto.no_dossard,
                date_debut_avec_equipe = equipe_joueurDto.date_debut_avec_equipe,
                date_fin_avec_equipe = equipe_joueurDto.date_fin_avec_equipe
            };

            _context.Entry(equipe_joueurBd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!equipe_joueurBdExists(id))
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

        // POST: api/equipe_joueurBds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<equipe_joueurDto>> Postequipe_joueurBd(equipe_joueurDto equipe_joueurDto)
        {
            var equipe_joueurBd = new equipe_joueurBd
            {
                no_equipe = equipe_joueurDto.no_equipe,
                no_joueur = equipe_joueurDto.no_joueur,
                no_dossard = equipe_joueurDto.no_dossard,
                date_debut_avec_equipe = equipe_joueurDto.date_debut_avec_equipe,
                date_fin_avec_equipe = equipe_joueurDto.date_fin_avec_equipe
            };

            _context.equipe_joueur.Add(equipe_joueurBd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (equipe_joueurBdExists(equipe_joueurBd.no_equipe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(equipe_joueurDto), new { id = equipe_joueurBd.no_equipe }, equipe_joueurDto);
        }

        // DELETE: api/equipe_joueurBds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteequipe_joueurBd(int id)
        {
            var equipe_joueurBd = await _context.equipe_joueur.FindAsync(id);
            if (equipe_joueurBd == null)
            {
                return NotFound();
            }

            _context.equipe_joueur.Remove(equipe_joueurBd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool equipe_joueurBdExists(int id)
        {
            return _context.equipe_joueur.Any(e => e.no_equipe == id);
        }
    }
}
