using OverdeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;

namespace OverdeRheinKraanKeuringen.DAL
{
    public class OpdrachtInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OpdrachtContext>
    {
        protected override void Seed(OpdrachtContext context)
        {
            var opdrachten = new List<Opdracht>
            {
            new Opdracht{ WerkInstructie="maak iets anders", DatumUitvoering = DateTime.Parse("2002-09-01"), KabelLeverancier="Jan jansssen",Waarnemingen="ik heb niets gezien",Image=new byte[] { 1, 1, 1, 1, 1, 1, 1 } ,Bedrijfsuren=1,AflegRedenen="omdat het moet"}
            };
            opdrachten.ForEach(s => context.Opdrachten.Add(s));
            context.SaveChanges();
            var kabelchecklists = new List<Kabelchecklist>
            {
            new Kabelchecklist{Breuk6D=1, Breuk30D=1, BeschadigingBuitenzijde=Waarde.gemiddeld, BeschadigingRoestCorrosie=Waarde.gemiddeld, VerminderdeKabeldiameter=1, PositieMeetpunten=1, BeschadigingTotaal=Waarde.gemiddeld, TypeBeschadigingEnVervormingen = "Testing", Opdrachtnummer=1}
            };
            kabelchecklists.ForEach(s => context.Kabelchecklists.Add(s));
            context.SaveChanges();
        }
    }
}