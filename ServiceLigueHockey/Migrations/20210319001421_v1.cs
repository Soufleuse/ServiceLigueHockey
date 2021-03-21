using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLigueHockey.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    No_Equipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Equipe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipe");
        }
    }
}
