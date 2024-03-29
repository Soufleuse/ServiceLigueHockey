﻿using System;

namespace ServiceLigueHockey.Models.Dto
{
    public class equipe_joueurDto
    {
        public int no_equipe { get; set; }

        public int no_joueur { get; set; }

        public string prenom_nom_joueur { get; set; }

        public DateTime date_debut_avec_equipe { get; set; }

        public DateTime? date_fin_avec_equipe { get; set; }

        public short no_dossard { get; set; }
    }
}
