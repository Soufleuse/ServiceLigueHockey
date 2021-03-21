using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceLigueHockey.Models
{
    public class JoueurBd
    {
        [Key]
        public int No_Joueur { get; set; }

        [MaxLength(50)]
        public string Prenom { get; set; }
        
        [MaxLength(50)]
        public string Nom { get; set; }
        
        public DateTime Date_Naissance { get; set; }

        [MaxLength(50)]
        public string Ville_naissance { get; set; }
        
        [MaxLength(50)]
        public string Pays_origine { get; set; }
    }
}
