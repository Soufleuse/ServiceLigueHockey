using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ServiceLigueHockey.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Table Equipe
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    No_Equipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Equipe = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Ville = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Annee_debut = table.Column<int>(type: "int", nullable: false),
                    Annee_fin = table.Column<int>(type: "int", nullable: true),
                    Est_Devenue_Equipe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.No_Equipe);
                });

            migrationBuilder.InsertData(
                table: "Equipe",
                columns: new[] { "No_Equipe", "Annee_debut", "Annee_fin", "Est_Devenue_Equipe", "Nom_Equipe", "Ville" },
                values: new object[,]
                {
                    { 1, 1989, null, null, "Canadiensssss", "Mourial" },
                    { 2, 1984, null, null, "Bruns", "Albany" },
                    { 3, 1976, null, null, "Harfangs", "Hartford" },
                    { 4, 1999, null, null, "Boulettes", "Victoriaville" },
                    { 5, 2001, null, null, "Rocher", "Percé" },
                    { 6, 1986, null, null, "Pierre", "Rochester" }
                });

            // Table Joueur
            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    No_Joueur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Date_Naissance = table.Column<DateTime>(type: "Date", nullable: false),
                    Ville_naissance = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Pays_origine = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.No_Joueur);
                    table.UniqueConstraint("CU_Joueur", x => new { x.Prenom, x.Nom, x.Date_Naissance });
                });

            migrationBuilder.InsertData(
                table: "Joueur",
                columns: new[] { "No_Joueur", "Prenom", "Nom", "Date_Naissance", "Ville_naissance", "Pays_origine" },
                values: new object[,]
                {
                    { 1, "Jack", "Tremblay", new DateTime(1988, 10, 20), "Lévis", "Canada" },
                    { 2, "Simon", "Lajeunesse", new DateTime(1996, 1, 25), "St-Stanislas", "Canada" },
                    { 3, "Mathieu", "Grandpré", new DateTime(1995, 3, 5), "Val d\'or", "Canada" },
                    { 4, "Ryan", "Callahan", new DateTime(1991, 3, 15), "London", "Canada" },
                    { 5, "Drew", "McCain", new DateTime(1992, 6, 18), "Albany", "États-Unis" },
                    { 6, "John", "Harris", new DateTime(2000, 9, 10), "Chico", "États-Unis" },
                    { 7, "Phil", "Rodgers", new DateTime(1996, 12, 21), "Calgary", "Canada" },
                    { 8, "Ted", "Rodriguez", new DateTime(1992, 10, 21), "Regina", "Canada" },
                    { 9, "Patrice", "Lemieux", new DateTime(1998, 4, 21), "Chibougamau", "Canada" },
                    { 10, "Maurice", "Béliveau", new DateTime(1997, 6, 1), "Beauceville", "Canada" },
                    { 11, "Andrew", "Cruz", new DateTime(1997, 7, 30), "Dallas", "États-Unis" },
                    { 12, "Chris", "Trout", new DateTime(1991, 8, 20), "Eau Claire", "États-Unis" },
                    { 13, "Sergei", "Datzyuk", new DateTime(1992, 9, 6), "Eau Claire", "États-Unis" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Joueur");
        }
    }
}
