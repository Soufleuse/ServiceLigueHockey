using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceLigueHockey.Models
{
    public class EquipeBd
    {
        [Key]
        public int No_Equipe { get; set; }

        [MaxLength(50)]
        public string Nom_Equipe { get; set; }

        [MaxLength(50)]
        public string Ville { get; set; }

        public Int32 Annee_debut { get; set; }

        public Int32? Annee_fin { get; set; }

        public int? Est_Devenue_Equipe { get; set; }

        public ICollection<equipe_joueurBd> listeEquipeJoueur { get; set; }
    }
}
