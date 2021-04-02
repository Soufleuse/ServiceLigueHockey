﻿// <auto-generated />
using System;
using IBM.EntityFrameworkCore;
using IBM.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceLigueHockey.Data;

namespace ServiceLigueHockey.Migrations
{
    [DbContext(typeof(ServiceLigueHockeyContext))]
    [Migration("20210402210337_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Db2:ValueGenerationStrategy", Db2ValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceLigueHockey.Models.EquipeBd", b =>
                {
                    b.Property<int>("No_Equipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Db2:ValueGenerationStrategy", Db2ValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Annee_debut")
                        .HasColumnType("int");

                    b.Property<int?>("Annee_fin")
                        .HasColumnType("int");

                    b.Property<int?>("Est_Devenue_Equipe")
                        .HasColumnType("int");

                    b.Property<string>("Nom_Equipe")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ville")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("No_Equipe");

                    b.ToTable("Equipe");

                    b.HasData(
                        new
                        {
                            No_Equipe = 1,
                            Annee_debut = 1989,
                            Nom_Equipe = "Canadiensssss",
                            Ville = "Mourial"
                        },
                        new
                        {
                            No_Equipe = 2,
                            Annee_debut = 1984,
                            Nom_Equipe = "Bruns",
                            Ville = "Albany"
                        },
                        new
                        {
                            No_Equipe = 3,
                            Annee_debut = 1976,
                            Nom_Equipe = "Harfangs",
                            Ville = "Hartford"
                        },
                        new
                        {
                            No_Equipe = 4,
                            Annee_debut = 1999,
                            Nom_Equipe = "Boulettes",
                            Ville = "Victoriaville"
                        },
                        new
                        {
                            No_Equipe = 5,
                            Annee_debut = 2001,
                            Nom_Equipe = "Rocher",
                            Ville = "Percé"
                        },
                        new
                        {
                            No_Equipe = 6,
                            Annee_debut = 1986,
                            Nom_Equipe = "Pierre",
                            Ville = "Rochester"
                        });
                });

            modelBuilder.Entity("ServiceLigueHockey.Models.JoueurBd", b =>
                {
                    b.Property<int>("No_Joueur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Db2:ValueGenerationStrategy", Db2ValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Naissance")
                        .HasColumnType("timestamp(6)");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pays_origine")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ville_naissance")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("No_Joueur");

                    b.ToTable("Joueur");

                    b.HasData(
                        new
                        {
                            No_Joueur = 1,
                            Date_Naissance = new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Tremblay",
                            Pays_origine = "Canada",
                            Prenom = "Jack",
                            Ville_naissance = "Lévis"
                        },
                        new
                        {
                            No_Joueur = 2,
                            Date_Naissance = new DateTime(1996, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Lajeunesse",
                            Pays_origine = "Canada",
                            Prenom = "Simon",
                            Ville_naissance = "St-Stanislas"
                        },
                        new
                        {
                            No_Joueur = 3,
                            Date_Naissance = new DateTime(1995, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Grandpré",
                            Pays_origine = "Canada",
                            Prenom = "Mathieu",
                            Ville_naissance = "Val d'or"
                        },
                        new
                        {
                            No_Joueur = 4,
                            Date_Naissance = new DateTime(1991, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Callahan",
                            Pays_origine = "Canada",
                            Prenom = "Ryan",
                            Ville_naissance = "London"
                        },
                        new
                        {
                            No_Joueur = 5,
                            Date_Naissance = new DateTime(1992, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "McCain",
                            Pays_origine = "États-Unis",
                            Prenom = "Drew",
                            Ville_naissance = "Albany"
                        },
                        new
                        {
                            No_Joueur = 6,
                            Date_Naissance = new DateTime(2000, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Harris",
                            Pays_origine = "États-Unis",
                            Prenom = "John",
                            Ville_naissance = "Chico"
                        },
                        new
                        {
                            No_Joueur = 7,
                            Date_Naissance = new DateTime(1996, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Rodgers",
                            Pays_origine = "Canada",
                            Prenom = "Phil",
                            Ville_naissance = "Calgary"
                        },
                        new
                        {
                            No_Joueur = 8,
                            Date_Naissance = new DateTime(1992, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Rodriguez",
                            Pays_origine = "Canada",
                            Prenom = "Ted",
                            Ville_naissance = "Regina"
                        },
                        new
                        {
                            No_Joueur = 9,
                            Date_Naissance = new DateTime(1998, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Lemieux",
                            Pays_origine = "Canada",
                            Prenom = "Patrice",
                            Ville_naissance = "Chibougamau"
                        },
                        new
                        {
                            No_Joueur = 10,
                            Date_Naissance = new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Béliveau",
                            Pays_origine = "Canada",
                            Prenom = "Maurice",
                            Ville_naissance = "Beauceville"
                        },
                        new
                        {
                            No_Joueur = 11,
                            Date_Naissance = new DateTime(1997, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Cruz",
                            Pays_origine = "États-Unis",
                            Prenom = "Andrew",
                            Ville_naissance = "Dallas"
                        },
                        new
                        {
                            No_Joueur = 12,
                            Date_Naissance = new DateTime(1991, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Trout",
                            Pays_origine = "États-Unis",
                            Prenom = "Chris",
                            Ville_naissance = "Eau Claire"
                        },
                        new
                        {
                            No_Joueur = 13,
                            Date_Naissance = new DateTime(1992, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nom = "Datzyuk",
                            Pays_origine = "États-Unis",
                            Prenom = "Sergei",
                            Ville_naissance = "Eau Claire"
                        });
                });

            modelBuilder.Entity("ServiceLigueHockey.Models.StatsJoueurBd", b =>
                {
                    b.Property<int>("No_JoueurRefId")
                        .HasColumnType("int");

                    b.Property<short>("AnneeStats")
                        .HasColumnType("smallint");

                    b.Property<int>("ButsAlloues")
                        .HasColumnType("int");

                    b.Property<short>("Defaites")
                        .HasColumnType("smallint");

                    b.Property<short>("DefaitesEnProlongation")
                        .HasColumnType("smallint");

                    b.Property<double>("MinutesJouees")
                        .HasColumnType("float");

                    b.Property<short>("NbButs")
                        .HasColumnType("smallint");

                    b.Property<short>("NbMinutesPenalites")
                        .HasColumnType("smallint");

                    b.Property<short>("NbPartiesJouees")
                        .HasColumnType("smallint");

                    b.Property<short>("NbPasses")
                        .HasColumnType("smallint");

                    b.Property<short>("NbPoints")
                        .HasColumnType("smallint");

                    b.Property<short>("Nulles")
                        .HasColumnType("smallint");

                    b.Property<short>("PlusseMoins")
                        .HasColumnType("smallint");

                    b.Property<int>("TirsAlloues")
                        .HasColumnType("int");

                    b.Property<short>("Victoires")
                        .HasColumnType("smallint");

                    b.HasKey("No_JoueurRefId", "AnneeStats");

                    b.ToTable("StatsJoueur");

                    b.HasData(
                        new
                        {
                            No_JoueurRefId = 1,
                            AnneeStats = (short)2020,
                            ButsAlloues = 0,
                            Defaites = (short)0,
                            DefaitesEnProlongation = (short)0,
                            MinutesJouees = 500.0,
                            NbButs = (short)10,
                            NbMinutesPenalites = (short)15,
                            NbPartiesJouees = (short)25,
                            NbPasses = (short)20,
                            NbPoints = (short)30,
                            Nulles = (short)0,
                            PlusseMoins = (short)5,
                            TirsAlloues = 0,
                            Victoires = (short)0
                        },
                        new
                        {
                            No_JoueurRefId = 2,
                            AnneeStats = (short)2020,
                            ButsAlloues = 0,
                            Defaites = (short)0,
                            DefaitesEnProlongation = (short)0,
                            MinutesJouees = 500.0,
                            NbButs = (short)15,
                            NbMinutesPenalites = (short)51,
                            NbPartiesJouees = (short)25,
                            NbPasses = (short)10,
                            NbPoints = (short)25,
                            Nulles = (short)0,
                            PlusseMoins = (short)-2,
                            TirsAlloues = 0,
                            Victoires = (short)0
                        },
                        new
                        {
                            No_JoueurRefId = 3,
                            AnneeStats = (short)2020,
                            ButsAlloues = 0,
                            Defaites = (short)0,
                            DefaitesEnProlongation = (short)0,
                            MinutesJouees = 500.0,
                            NbButs = (short)5,
                            NbMinutesPenalites = (short)35,
                            NbPartiesJouees = (short)25,
                            NbPasses = (short)24,
                            NbPoints = (short)29,
                            Nulles = (short)0,
                            PlusseMoins = (short)25,
                            TirsAlloues = 0,
                            Victoires = (short)0
                        },
                        new
                        {
                            No_JoueurRefId = 4,
                            AnneeStats = (short)2020,
                            ButsAlloues = 53,
                            Defaites = (short)2,
                            DefaitesEnProlongation = (short)6,
                            MinutesJouees = 1500.0,
                            NbButs = (short)0,
                            NbMinutesPenalites = (short)4,
                            NbPartiesJouees = (short)25,
                            NbPasses = (short)0,
                            NbPoints = (short)0,
                            Nulles = (short)0,
                            PlusseMoins = (short)0,
                            TirsAlloues = 564,
                            Victoires = (short)9
                        });
                });

            modelBuilder.Entity("ServiceLigueHockey.Models.equipe_joueurBd", b =>
                {
                    b.Property<int>("no_equipe")
                        .HasColumnType("int");

                    b.Property<int>("no_joueur")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_debut_avec_equipe")
                        .HasColumnType("timestamp(6)");

                    b.Property<DateTime?>("date_fin_avec_equipe")
                        .HasColumnType("timestamp(6)");

                    b.Property<int?>("equipeBdNo_Equipe")
                        .HasColumnType("int");

                    b.Property<int?>("joueurBdNo_Joueur")
                        .HasColumnType("int");

                    b.Property<short>("no_dossard")
                        .HasColumnType("smallint");

                    b.HasKey("no_equipe", "no_joueur", "date_debut_avec_equipe");

                    b.HasIndex("equipeBdNo_Equipe");

                    b.HasIndex("joueurBdNo_Joueur");

                    b.ToTable("equipe_joueur");

                    b.HasData(
                        new
                        {
                            no_equipe = 1,
                            no_joueur = 1,
                            date_debut_avec_equipe = new DateTime(2008, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)23
                        },
                        new
                        {
                            no_equipe = 1,
                            no_joueur = 2,
                            date_debut_avec_equipe = new DateTime(2016, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)24
                        },
                        new
                        {
                            no_equipe = 1,
                            no_joueur = 3,
                            date_debut_avec_equipe = new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)25
                        },
                        new
                        {
                            no_equipe = 1,
                            no_joueur = 4,
                            date_debut_avec_equipe = new DateTime(2013, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)26
                        },
                        new
                        {
                            no_equipe = 2,
                            no_joueur = 5,
                            date_debut_avec_equipe = new DateTime(2014, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)27
                        },
                        new
                        {
                            no_equipe = 2,
                            no_joueur = 6,
                            date_debut_avec_equipe = new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)28
                        },
                        new
                        {
                            no_equipe = 2,
                            no_joueur = 7,
                            date_debut_avec_equipe = new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)29
                        },
                        new
                        {
                            no_equipe = 2,
                            no_joueur = 8,
                            date_debut_avec_equipe = new DateTime(2010, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)30
                        },
                        new
                        {
                            no_equipe = 3,
                            no_joueur = 9,
                            date_debut_avec_equipe = new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)31
                        },
                        new
                        {
                            no_equipe = 3,
                            no_joueur = 10,
                            date_debut_avec_equipe = new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)32
                        },
                        new
                        {
                            no_equipe = 3,
                            no_joueur = 11,
                            date_debut_avec_equipe = new DateTime(2018, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)33
                        },
                        new
                        {
                            no_equipe = 4,
                            no_joueur = 12,
                            date_debut_avec_equipe = new DateTime(2011, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)34
                        },
                        new
                        {
                            no_equipe = 4,
                            no_joueur = 13,
                            date_debut_avec_equipe = new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            no_dossard = (short)35
                        });
                });

            modelBuilder.Entity("ServiceLigueHockey.Models.StatsJoueurBd", b =>
                {
                    b.HasOne("ServiceLigueHockey.Models.JoueurBd", "Joueur")
                        .WithMany()
                        .HasForeignKey("No_JoueurRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Joueur");
                });

            modelBuilder.Entity("ServiceLigueHockey.Models.equipe_joueurBd", b =>
                {
                    b.HasOne("ServiceLigueHockey.Models.EquipeBd", "equipeBd")
                        .WithMany("listeEquipeJoueur")
                        .HasForeignKey("equipeBdNo_Equipe");

                    b.HasOne("ServiceLigueHockey.Models.JoueurBd", "joueurBd")
                        .WithMany("listeEquipeJoueur")
                        .HasForeignKey("joueurBdNo_Joueur");

                    b.Navigation("equipeBd");

                    b.Navigation("joueurBd");
                });

            modelBuilder.Entity("ServiceLigueHockey.Models.EquipeBd", b =>
                {
                    b.Navigation("listeEquipeJoueur");
                });

            modelBuilder.Entity("ServiceLigueHockey.Models.JoueurBd", b =>
                {
                    b.Navigation("listeEquipeJoueur");
                });
#pragma warning restore 612, 618
        }
    }
}
