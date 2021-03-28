using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ServiceLigueHockey.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Table Equipe_joueur
            migrationBuilder.CreateTable(
                name: "equipe_joueur",
                columns: table => new
                {
                    no_equipe = table.Column<int>(type: "int", nullable: false),
                    no_joueur = table.Column<int>(type: "int", nullable: false),
                    date_debut_avec_equipe = table.Column<DateTime>(type: "Date", nullable: false),
                    date_fin_avec_equipe = table.Column<DateTime>(type: "Date", nullable: true),
                    no_dossard = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipe_joueur", x => new { x.no_equipe, x.no_joueur, x.date_debut_avec_equipe });
                });

            migrationBuilder.InsertData(
                table: "equipe_joueur",
                columns: new[] { "date_debut_avec_equipe", "no_equipe", "no_joueur", "date_fin_avec_equipe", "no_dossard" },
                values: new object[,]
                {
                    { new DateTime(2018, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, null, (short)33 },
                    { new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10, null, (short)32 },
                    { new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9, null, (short)31 },
                    { new DateTime(2010, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8, null, (short)30 },
                    { new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, null, (short)29 },
                    { new DateTime(2013, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, null, (short)26 },
                    { new DateTime(2014, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, null, (short)27 },
                    { new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, null, (short)25 },
                    { new DateTime(2016, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null, (short)24 },
                    { new DateTime(2008, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, (short)23 },
                    { new DateTime(2011, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12, null, (short)34 },
                    { new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, null, (short)28 },
                    { new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 13, null, (short)35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipe_joueur");
        }
    }
}
