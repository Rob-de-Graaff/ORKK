using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OverdeRheinKraanKeuringen.Models
{
    public class Kabelchecklist
    {
        
        public int kabelID { get; set; }
        public int Breuk_6D { get; set; }
        public int Breuk_30D { get; set; }
        public int Beschadiging_Buitenzijde { get; set; }
        public int Beschadiging_Roest_Corrosie { get; set; }
        public int Verminderde_Kabeldiameter { get; set; }
        public int Positie_Meetpunten { get; set; }
        public int Beschadiging_Totaal { get; set; }
        public int Type_Beschadiging_Roestvorming { get; set; }
        
        public int Opdrachtnummer { get; set; }
        public virtual Opdracht Opdracht { get; set; }
    }
}