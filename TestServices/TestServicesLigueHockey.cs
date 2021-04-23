using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLigueHockey.Controllers;
using ServiceLigueHockey.Data;
using ServiceLigueHockey.Models;
using ServiceLigueHockey.Models.Dto;

namespace TestServices
{
    [TestClass]
    public class TestServicesLigueHockey
    {
        [TestMethod]
        public void Succes_Lister_Equipes()
        {
            // Assigner
            var options = new DbContextOptionsBuilder<ServiceLigueHockeyContext>()
                .UseInMemoryDatabase(databaseName: "xxx").Options;
            using (var contexteDonnees = new ServiceLigueHockeyContext(options))
            {
                contexteDonnees.Equipe.Add(new EquipeBd { No_Equipe = 1 });
                contexteDonnees.Equipe.Add(new EquipeBd { No_Equipe = 2 });
                contexteDonnees.Equipe.Add(new EquipeBd { No_Equipe = 3 });
                contexteDonnees.SaveChanges();
            }

            using (var contextePropre = new ServiceLigueHockeyContext(options))
            {
                var equipeController = new EquipeBdsController(contextePropre);

                // Exécuter
                var maListe = equipeController.GetEquipeDto();

                // Valider
                Assert.IsTrue(maListe.Count() == 3);
            }
        }
    }
}
