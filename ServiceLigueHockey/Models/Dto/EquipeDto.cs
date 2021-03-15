using System;

namespace ServiceLigueHockey.Models.Dto
{
    public class EquipeDto
    {
        public int No_Equipe { get; set; }

        public string Nom_Equipe { get; set; }

        public string Ville { get; set; }

        public Int32 Annee_debut { get; set; }

        public Int32? Annee_fin { get; set; }

        public int? Est_Devenue_Equipe { get; set; }
    }
}
