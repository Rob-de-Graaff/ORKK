using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OverdeRheinKraanKeuringen.Models
{
    public class Kabelchecklist
    {
        [Key]
        public int KabelID { get; set; }
        public int Breuk6D { get; set; }
        public int Breuk30D { get; set; }
        public int BeschadigingBuitenzijde { get; set; }
        public int BeschadigingRoestCorrosie { get; set; }
        public int VerminderdeKabeldiameter { get; set; }
        public int PositieMeetpunten { get; set; }
        public int BeschadigingTotaal { get; set; }

        [ForeignKey("Opdracht")]
        public int Opdrachtnummer { get; set; }
        public virtual Opdracht Opdracht { get; set; }
    }
}