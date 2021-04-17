using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLigueHockey.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lemste");

            migrationBuilder.CreateTable(
                name: "Equipe",
                schema: "lemste",
                columns: table => new
                {
                    No_Equipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Db2:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "Joueur",
                schema: "lemste",
                columns: table => new
                {
                    No_Joueur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Db2:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Date_Naissance = table.Column<DateTime>(type: "timestamp(6)", nullable: false),
                    Ville_naissance = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Pays_origine = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.No_Joueur);
                });

            migrationBuilder.CreateTable(
                name: "equipe_joueur",
                schema: "lemste",
                columns: table => new
                {
                    no_equipe = table.Column<int>(type: "int", nullable: false),
                    no_joueur = table.Column<int>(type: "int", nullable: false),
                    date_debut_avec_equipe = table.Column<DateTime>(type: "timestamp(6)", nullable: false),
                    equipeBdNo_Equipe = table.Column<int>(type: "int", nullable: true),
                    joueurBdNo_Joueur = table.Column<int>(type: "int", nullable: true),
                    date_fin_avec_equipe = table.Column<DateTime>(type: "timestamp(6)", nullable: true),
                    no_dossard = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipe_joueur", x => new { x.no_equipe, x.no_joueur, x.date_debut_avec_equipe });
                    table.ForeignKey(
                        name: "FK_equipe_joueur_Equipe_equipeBdNo_Equipe",
                        column: x => x.equipeBdNo_Equipe,
                        principalSchema: "lemste",
                        principalTable: "Equipe",
                        principalColumn: "No_Equipe",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_equipe_joueur_Joueur_joueurBdNo_Joueur",
                        column: x => x.joueurBdNo_Joueur,
                        principalSchema: "lemste",
                        principalTable: "Joueur",
                        principalColumn: "No_Joueur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatsJoueur",
                schema: "lemste",
                columns: table => new
                {
                    AnneeStats = table.Column<short>(type: "smallint", nullable: false),
                    No_JoueurRefId = table.Column<int>(type: "int", nullable: false),
                    NbPartiesJouees = table.Column<short>(type: "smallint", nullable: false),
                    NbButs = table.Column<short>(type: "smallint", nullable: false),
                    NbPasses = table.Column<short>(type: "smallint", nullable: false),
                    NbPoints = table.Column<short>(type: "smallint", nullable: false),
                    NbMinutesPenalites = table.Column<short>(type: "smallint", nullable: false),
                    PlusseMoins = table.Column<short>(type: "smallint", nullable: false),
                    Victoires = table.Column<short>(type: "smallint", nullable: false),
                    Defaites = table.Column<short>(type: "smallint", nullable: false),
                    Nulles = table.Column<short>(type: "smallint", nullable: false),
                    DefaitesEnProlongation = table.Column<short>(type: "smallint", nullable: false),
                    ButsAlloues = table.Column<int>(type: "int", nullable: false),
                    TirsAlloues = table.Column<int>(type: "int", nullable: false),
                    MinutesJouees = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsJoueur", x => new { x.No_JoueurRefId, x.AnneeStats });
                    table.ForeignKey(
                        name: "FK_StatsJoueur_Joueur_No_JoueurRefId",
                        column: x => x.No_JoueurRefId,
                        principalSchema: "lemste",
                        principalTable: "Joueur",
                        principalColumn: "No_Joueur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "lemste",
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

            migrationBuilder.InsertData(
                schema: "lemste",
                table: "Joueur",
                columns: new[] { "No_Joueur", "Date_Naissance", "Nom", "Pays_origine", "Prenom", "Ville_naissance" },
                values: new object[,]
                {
                    { 13, new DateTime(1992, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Datzyuk", "États-Unis", "Sergei", "Eau Claire" },
                    { 12, new DateTime(1991, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trout", "États-Unis", "Chris", "Eau Claire" },
                    { 11, new DateTime(1997, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cruz", "États-Unis", "Andrew", "Dallas" },
                    { 9, new DateTime(1998, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lemieux", "Canada", "Patrice", "Chibougamau" },
                    { 8, new DateTime(1992, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodriguez", "Canada", "Ted", "Regina" },
                    { 7, new DateTime(1996, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodgers", "Canada", "Phil", "Calgary" },
                    { 10, new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Béliveau", "Canada", "Maurice", "Beauceville" },
                    { 5, new DateTime(1992, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "McCain", "États-Unis", "Drew", "Albany" },
                    { 4, new DateTime(1991, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Callahan", "Canada", "Ryan", "London" },
                    { 3, new DateTime(1995, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grandpré", "Canada", "Mathieu", "Val d'or" },
                    { 2, new DateTime(1996, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lajeunesse", "Canada", "Simon", "St-Stanislas" },
                    { 1, new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tremblay", "Canada", "Jack", "Lévis" },
                    { 6, new DateTime(2000, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harris", "États-Unis", "John", "Chico" }
                });

            migrationBuilder.InsertData(
                schema: "lemste",
                table: "equipe_joueur",
                columns: new[] { "date_debut_avec_equipe", "no_equipe", "no_joueur", "date_fin_avec_equipe", "equipeBdNo_Equipe", "joueurBdNo_Joueur", "no_dossard" },
                values: new object[,]
                {
                    { new DateTime(2018, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, null, null, null, (short)33 },
                    { new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10, null, null, null, (short)32 },
                    { new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9, null, null, null, (short)31 },
                    { new DateTime(2010, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8, null, null, null, (short)30 },
                    { new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, null, null, null, (short)29 },
                    { new DateTime(2013, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, null, null, null, (short)26 },
                    { new DateTime(2014, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, null, null, null, (short)27 },
                    { new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, null, null, null, (short)25 },
                    { new DateTime(2016, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null, null, null, (short)24 },
                    { new DateTime(2008, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, null, null, (short)23 },
                    { new DateTime(2011, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12, null, null, null, (short)34 },
                    { new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, null, null, null, (short)28 },
                    { new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 13, null, null, null, (short)35 }
                });

            migrationBuilder.InsertData(
                schema: "lemste",
                table: "StatsJoueur",
                columns: new[] { "AnneeStats", "No_JoueurRefId", "ButsAlloues", "Defaites", "DefaitesEnProlongation", "MinutesJouees", "NbButs", "NbMinutesPenalites", "NbPartiesJouees", "NbPasses", "NbPoints", "Nulles", "PlusseMoins", "TirsAlloues", "Victoires" },
                values: new object[,]
                {
                    { (short)2020, 1, 0, (short)0, (short)0, 500.0, (short)10, (short)15, (short)25, (short)20, (short)30, (short)0, (short)5, 0, (short)0 },
                    { (short)2019, 1, 0, (short)0, (short)0, 500.0, (short)1910, (short)15, (short)82, (short)20, (short)1930, (short)0, (short)5, 0, (short)0 },
                    { (short)2018, 1, 0, (short)0, (short)0, 500.0, (short)1810, (short)15, (short)65, (short)20, (short)1830, (short)0, (short)5, 0, (short)0 },
                    { (short)2020, 2, 0, (short)0, (short)0, 500.0, (short)15, (short)51, (short)25, (short)10, (short)25, (short)0, (short)-2, 0, (short)0 },
                    { (short)2019, 2, 0, (short)0, (short)0, 500.0, (short)1915, (short)51, (short)82, (short)10, (short)1925, (short)0, (short)-2, 0, (short)0 },
                    { (short)2018, 2, 0, (short)0, (short)0, 500.0, (short)1815, (short)51, (short)65, (short)10, (short)1825, (short)0, (short)-2, 0, (short)0 },
                    { (short)2020, 3, 0, (short)0, (short)0, 500.0, (short)5, (short)35, (short)25, (short)24, (short)29, (short)0, (short)25, 0, (short)0 },
                    { (short)2019, 3, 0, (short)0, (short)0, 500.0, (short)1905, (short)35, (short)82, (short)24, (short)1929, (short)0, (short)25, 0, (short)0 },
                    { (short)2018, 3, 0, (short)0, (short)0, 500.0, (short)1805, (short)35, (short)65, (short)24, (short)1829, (short)0, (short)25, 0, (short)0 },
                    { (short)2020, 4, 53, (short)2, (short)6, 1500.0, (short)0, (short)4, (short)25, (short)0, (short)0, (short)0, (short)0, 564, (short)9 },
                    { (short)2019, 4, 53, (short)2, (short)6, 1500.0, (short)1900, (short)4, (short)82, (short)0, (short)1900, (short)0, (short)0, 564, (short)9 },
                    { (short)2018, 4, 53, (short)2, (short)6, 1500.0, (short)1800, (short)4, (short)65, (short)0, (short)1800, (short)0, (short)0, 564, (short)9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipe_joueur_equipeBdNo_Equipe",
                schema: "lemste",
                table: "equipe_joueur",
                column: "equipeBdNo_Equipe");

            migrationBuilder.CreateIndex(
                name: "IX_equipe_joueur_joueurBdNo_Joueur",
                schema: "lemste",
                table: "equipe_joueur",
                column: "joueurBdNo_Joueur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipe_joueur",
                schema: "lemste");

            migrationBuilder.DropTable(
                name: "StatsJoueur",
                schema: "lemste");

            migrationBuilder.DropTable(
                name: "Equipe",
                schema: "lemste");

            migrationBuilder.DropTable(
                name: "Joueur",
                schema: "lemste");
        }
    }
}
