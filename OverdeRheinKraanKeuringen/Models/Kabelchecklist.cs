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
        [Range(0,int.MaxValue)]
        public int Breuk6D { get; set; }
        [Range(0, int.MaxValue)]
        public int Breuk30D { get; set; }
        [Range(1, 4)]
        public int BeschadigingBuitenzijde { get; set; }
        [Range(1, 4)]
        public int BeschadigingRoestCorrosie { get; set; }
        [Range(0, int.MaxValue)]
        public int VerminderdeKabeldiameter { get; set; }
        [Range(0, int.MaxValue)]
        public int PositieMeetpunten { get; set; }
        [Range(0, int.MaxValue)]
        public int BeschadigingTotaal { get; set; }

        [ForeignKey("Opdracht")]
        public int Opdrachtnummer { get; set; }
        public virtual Opdracht Opdracht { get; set; }
    }
}