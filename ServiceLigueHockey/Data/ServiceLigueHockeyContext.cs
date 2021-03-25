using Microsoft.EntityFrameworkCore;
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

        public DbSet<EquipBd> Equipe { get; set; }

        public DbSet<JoueurBd> Joueur { get; set; }

        public DbSet<equipe_joueurBd> equipe_joueur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=VMWIN10PRO\\SQLEXPRESS;Database=LigueHockey;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EquipBd>()
                .HasData(
                new EquipBd { No_Equipe = 1, Nom_Equipe = "Canadiensssss", Ville = "Mourial", Annee_debut = 1989 },
                new EquipBd { No_Equipe = 2, Nom_Equipe = "Bruns", Ville = "Albany", Annee_debut = 1984 },
                new EquipBd { No_Equipe = 3, Nom_Equipe = "Harfangs", Ville = "Hartford", Annee_debut = 1976 },
                new EquipBd { No_Equipe = 4, Nom_Equipe = "Boulettes", Ville = "Victoriaville", Annee_debut = 1999 },
                new EquipBd { No_Equipe = 5, Nom_Equipe = "Rocher", Ville = "Percé", Annee_debut = 2001 },
                new EquipBd { No_Equipe = 6, Nom_Equipe = "Pierre", Ville = "Rochester", Annee_debut = 1986 }
                );

            modelBuilder.Entity<equipe_joueurBd>()
                .HasKey(c => new { c.no_equipe, c.no_joueur, c.date_debut_avec_equipe });
            //modelBuilder.Entity<>
        }
    }
}
