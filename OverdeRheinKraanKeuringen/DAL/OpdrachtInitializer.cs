using OverdeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverdeRheinKraanKeuringen.DAL
{
    public class OpdrachtInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OpdrachtContext>
    {
        protected override void Seed(OpdrachtContext context)
        {
            var opdrachten = new List<Opdracht>
            {
            new Opdracht{ WerkInstructie="maak", DatumUitvoering = DateTime.Parse("2002-09-01"), KabelLeverancier="Jan",Waarnemingen="",Image=new byte[] { 1, 1, 1, 1, 1, 1, 1 } ,Bedrijfsuren=1,AflegRedenen=""}
            };
            opdrachten.ForEach(s => context.Opdrachten.Add(s));
            context.SaveChanges();
            var kabelchecklists = new List<Kabelchecklist>
            {
            new Kabelchecklist{Breuk6D=1, Breuk30D=1, BeschadigingBuitenzijde=1, BeschadigingRoestCorrosie=1, VerminderdeKabeldiameter=1, PositieMeetpunten=1, BeschadigingTotaal=1, Opdrachtnummer=1}
            };
            kabelchecklists.ForEach(s => context.Kabelchecklists.Add(s));
            context.SaveChanges();
        }
    }
}