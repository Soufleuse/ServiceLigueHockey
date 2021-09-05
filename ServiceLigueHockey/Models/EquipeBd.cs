using System;
using System.Collections.Generic;
// Voir la remarque de la classe class EquipeBd pour le prochain using.
//using System.ComponentModel.DataAnnotations;

namespace ServiceLigueHockey.Models
{
    /// <summary>
    /// Classe représentant une équipe
    /// </summary>
    /// <remarks>
    /// Les annotations sont mises en commentaire parce qu'implémentés dans la méthode OnModelCreating de
    /// la classe ServiceLigueHockeyContext via le ModelBuilder. Les annotations sont laissées là pour
    /// dire qu'est-ce qu'il faudrait faire si on enlève les APIs Fluent de la méthode mentionnée
    /// précédemment.
    /// </remarks>
    public class EquipeBd
    {
        //[Key]
        public int No_Equipe { get; set; }

        //[MaxLength(50)]
        public string Nom_Equipe { get; set; }

        //[MaxLength(50)]
        public string Ville { get; set; }

        public Int32 Annee_debut { get; set; }

        public Int32? Annee_fin { get; set; }

        public int? Est_Devenue_Equipe { get; set; }

        public ICollection<equipe_joueurBd> listeEquipeJoueur { get; set; }
    }
}
