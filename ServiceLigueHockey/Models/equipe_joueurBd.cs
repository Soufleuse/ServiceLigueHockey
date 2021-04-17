using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLigueHockey.Models
{
    public class equipe_joueurBd
    {
        [ForeignKey("Equipe")]
        public int no_equipe { get; set; }
        public EquipeBd equipeBd { get; set; }

        [ForeignKey("Joueur")]
        public int no_joueur { get; set; }
        public JoueurBd joueurBd { get; set; }

        public DateTime date_debut_avec_equipe { get; set; }
        
        public DateTime? date_fin_avec_equipe { get; set; }
        
        public short no_dossard { get; set; }
    }
}
