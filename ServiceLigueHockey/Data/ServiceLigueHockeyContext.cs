using System;
using Microsoft.EntityFrameworkCore;
//using IBM.EntityFrameworkCore;
using ServiceLigueHockey.Models;

namespace ServiceLigueHockey.Data
{
    public class ServiceLigueHockeyContext : DbContext
    {
        public ServiceLigueHockeyContext() { }

        public ServiceLigueHockeyContext (DbContextOptions<ServiceLigueHockeyContext> options)
            : base(options)
        {
        }

        public DbSet<EquipeBd> Equipe { get; set; }

        public DbSet<JoueurBd> Joueur { get; set; }

        public DbSet<equipe_joueurBd> equipe_joueur { get; set; }

        public DbSet<StatsJoueurBd> StatsJoueurBd { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ché pas pourquoi, il a fallu mettre ça ici pour que je me pluggue sur mon instance SQLEXPRESS dans IIS normal.
            optionsBuilder.UseSqlServer("Server=VMWIN10PRO\\SQLEXPRESS;Database=LigueHockey;Trusted_Connection=True;MultipleActiveResultSets=true");
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=VMWIN10PRO\\SQLEXPRESS;Database=LigueHockey;Trusted_Connection=True;MultipleActiveResultSets=true");
                /*optionsBuilder.UseDb2("DATABASE=LigueO;SERVER=winServer2019:50000;UID=lemste;PWD=<mon mot de passe>;CurrentSchema=lemste;",
                    p => p.SetServerInfo(IBMDBServerType.LUW, IBMDBServerVersion.LUW_11_01_2020));*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO à mettre pour Db2
            //modelBuilder.HasDefaultSchema("lemste");

            modelBuilder.Entity<EquipeBd>().HasKey(c => new { c.No_Equipe });
            //modelBuilder.Entity("EquipeBd", b => { b.Property<string>("Nom_Equipe").HasMaxLength(50); });
            modelBuilder.Entity<EquipeBd>().Property<string>("Nom_Equipe").HasMaxLength(50);
            modelBuilder.Entity<EquipeBd>().Property<string>("Ville").HasMaxLength(50);

            /*modelBuilder.Entity<EquipeBd>()
                .HasData(
                new EquipeBd { No_Equipe = 1, Nom_Equipe = "Canadiensssss", Ville = "Mourial", Annee_debut = 1989 },
                new EquipeBd { No_Equipe = 2, Nom_Equipe = "Bruns", Ville = "Albany", Annee_debut = 1984 },
                new EquipeBd { No_Equipe = 3, Nom_Equipe = "Harfangs", Ville = "Hartford", Annee_debut = 1976 },
                new EquipeBd { No_Equipe = 4, Nom_Equipe = "Boulettes", Ville = "Victoriaville", Annee_debut = 1999 },
                new EquipeBd { No_Equipe = 5, Nom_Equipe = "Rocher", Ville = "Percé", Annee_debut = 2001 },
                new EquipeBd { No_Equipe = 6, Nom_Equipe = "Pierre", Ville = "Rochester", Annee_debut = 1986 }
                );

            modelBuilder.Entity<JoueurBd>()
                .HasData(
                new JoueurBd { No_Joueur = 1, Prenom = "Jack", Nom = "Tremblay", Date_Naissance = new DateTime(1988, 10, 20), Ville_naissance = "Lévis", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 2, Prenom = "Simon", Nom = "Lajeunesse", Date_Naissance = new DateTime(1996, 1, 25), Ville_naissance = "St-Stanislas", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 3, Prenom = "Mathieu", Nom = "Grandpré", Date_Naissance = new DateTime(1995, 3, 5), Ville_naissance = "Val d\'or", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 4, Prenom = "Ryan", Nom = "Callahan", Date_Naissance = new DateTime(1991, 3, 15), Ville_naissance = "London", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 5, Prenom = "Drew", Nom = "McCain", Date_Naissance = new DateTime(1992, 6, 18), Ville_naissance = "Albany", Pays_origine = "États-Unis" },
                new JoueurBd { No_Joueur = 6, Prenom = "John", Nom = "Harris", Date_Naissance = new DateTime(2000, 9, 10), Ville_naissance = "Chico", Pays_origine = "États-Unis" },
                new JoueurBd { No_Joueur = 7, Prenom = "Phil", Nom = "Rodgers", Date_Naissance = new DateTime(1996, 12, 21), Ville_naissance = "Calgary", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 8, Prenom = "Ted", Nom = "Rodriguez", Date_Naissance = new DateTime(1992, 10, 21), Ville_naissance = "Regina", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 9, Prenom = "Patrice", Nom = "Lemieux", Date_Naissance = new DateTime(1998, 4, 21), Ville_naissance = "Chibougamau", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 10, Prenom = "Maurice", Nom = "Béliveau", Date_Naissance = new DateTime(1997, 6, 1), Ville_naissance = "Beauceville", Pays_origine = "Canada" },
                new JoueurBd { No_Joueur = 11, Prenom = "Andrew", Nom = "Cruz", Date_Naissance = new DateTime(1997, 7, 30), Ville_naissance = "Dallas", Pays_origine = "États-Unis" },
                new JoueurBd { No_Joueur = 12, Prenom = "Chris", Nom = "Trout", Date_Naissance = new DateTime(1991, 8, 20), Ville_naissance = "Eau Claire", Pays_origine = "États-Unis" },
                new JoueurBd { No_Joueur = 13, Prenom = "Sergei", Nom = "Datzyuk", Date_Naissance = new DateTime(1992, 9, 6), Ville_naissance = "Eau Claire", Pays_origine = "États-Unis" }
                );*/

            modelBuilder.Entity<equipe_joueurBd>()
                .HasKey(c => new { c.no_equipe, c.no_joueur, c.date_debut_avec_equipe });
            /*modelBuilder.Entity<equipe_joueurBd>()
                .HasData(
                new equipe_joueurBd { no_equipe = 1, no_joueur = 1, no_dossard = 23, date_debut_avec_equipe = new DateTime(2008, 9, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 1, no_joueur = 2, no_dossard = 24, date_debut_avec_equipe = new DateTime(2016, 9, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 1, no_joueur = 3, no_dossard = 25, date_debut_avec_equipe = new DateTime(2017, 9, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 1, no_joueur = 4, no_dossard = 26, date_debut_avec_equipe = new DateTime(2013, 9, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 2, no_joueur = 5, no_dossard = 27, date_debut_avec_equipe = new DateTime(2014, 9, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 2, no_joueur = 6, no_dossard = 28, date_debut_avec_equipe = new DateTime(2020, 11, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 2, no_joueur = 7, no_dossard = 29, date_debut_avec_equipe = new DateTime(2018, 1, 15), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 2, no_joueur = 8, no_dossard = 30, date_debut_avec_equipe = new DateTime(2010, 9, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 3, no_joueur = 9, no_dossard = 31, date_debut_avec_equipe = new DateTime(2018, 4, 20), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 3, no_joueur = 10, no_dossard = 32, date_debut_avec_equipe = new DateTime(2018, 2, 13), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 3, no_joueur = 11, no_dossard = 33, date_debut_avec_equipe = new DateTime(2018, 10, 30), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 4, no_joueur = 12, no_dossard = 34, date_debut_avec_equipe = new DateTime(2011, 9, 10), date_fin_avec_equipe = null },
                new equipe_joueurBd { no_equipe = 4, no_joueur = 13, no_dossard = 35, date_debut_avec_equipe = new DateTime(2012, 8, 20), date_fin_avec_equipe = null }
                );*/

            modelBuilder.Entity<StatsJoueurBd>()
                .HasKey(d => new { d.No_JoueurRefId, d.AnneeStats });

            /*modelBuilder.Entity<StatsJoueurBd>()
                .HasData(
                new StatsJoueurBd { No_JoueurRefId = 1, AnneeStats = 2020, NbButs = 10, NbPasses = 20, NbPoints = 30, NbPartiesJouees = 25, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 2, AnneeStats = 2020, NbButs = 15, NbPasses = 10, NbPoints = 25, NbPartiesJouees = 25, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 3, AnneeStats = 2020, NbButs = 5, NbPasses = 24, NbPoints = 29, NbPartiesJouees = 25, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 4, AnneeStats = 2020, NbButs = 0, NbPasses = 0, NbPoints = 0, NbPartiesJouees = 25, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 },
                new StatsJoueurBd { No_JoueurRefId = 1, AnneeStats = 2019, NbButs = 1910, NbPasses = 20, NbPoints = 1930, NbPartiesJouees = 82, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 2, AnneeStats = 2019, NbButs = 1915, NbPasses = 10, NbPoints = 1925, NbPartiesJouees = 82, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 3, AnneeStats = 2019, NbButs = 1905, NbPasses = 24, NbPoints = 1929, NbPartiesJouees = 82, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 4, AnneeStats = 2019, NbButs = 1900, NbPasses = 0, NbPoints = 1900, NbPartiesJouees = 82, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 },
                new StatsJoueurBd { No_JoueurRefId = 1, AnneeStats = 2018, NbButs = 1810, NbPasses = 20, NbPoints = 1830, NbPartiesJouees = 65, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 2, AnneeStats = 2018, NbButs = 1815, NbPasses = 10, NbPoints = 1825, NbPartiesJouees = 65, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 3, AnneeStats = 2018, NbButs = 1805, NbPasses = 24, NbPoints = 1829, NbPartiesJouees = 65, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                new StatsJoueurBd { No_JoueurRefId = 4, AnneeStats = 2018, NbButs = 1800, NbPasses = 0, NbPoints = 1800, NbPartiesJouees = 65, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 }
                );*/
        }
    }
}
