using System;

namespace ServiceLigueHockey.Models.Dto
{
    public class JoueurDto
    {
        public int No_Joueur { get; set; }

        public string Prenom { get; set; }

        public string Nom { get; set; }

        public DateTime Date_Naissance { get; set; }

        public string ville_naissance { get; set; }

        public string pays_origine { get; set; }
    }
}
