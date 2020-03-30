namespace OverdeRheinKraanKeuringen.Migrations
{
    using OverdeRheinKraanKeuringen.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OverdeRheinKraanKeuringen.DAL.OpdrachtContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OverdeRheinKraanKeuringen.DAL.OpdrachtContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var opdrachten = new List<Opdracht>
            {
            new Opdracht{ WerkInstructie="maak iets anders", DatumUitvoering = DateTime.Parse("2002-09-01"), KabelLeverancier="Jan jansssen", Waarnemingen="ik heb niets gezien", Image=new byte[] { 1, 1, 1, 1, 1, 1, 1 }, Bedrijfsuren=1, AflegRedenen="omdat het moet"}
            };
            opdrachten.ForEach(o => context.Opdrachten.AddOrUpdate(p => p.OpdrachtNummer, o));
            context.SaveChanges();

            var kabelchecklists = new List<Kabelchecklist>
            {
            new Kabelchecklist{Breuk6D=1, Breuk30D=1, BeschadigingBuitenzijde=Waarde.gemiddeld, BeschadigingRoestCorrosie=Waarde.gemiddeld, VerminderdeKabeldiameter=1, PositieMeetpunten=1, BeschadigingTotaal=Waarde.gemiddeld, TypeBeschadigingEnVervormingen = "Testing", Opdrachtnummer=1}
            };
            kabelchecklists.ForEach(k => context.Kabelchecklists.AddOrUpdate(c => c.KabelID, k));
            context.SaveChanges();
        }
    }
}
