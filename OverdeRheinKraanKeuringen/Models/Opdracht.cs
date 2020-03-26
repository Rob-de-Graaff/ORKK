using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OverdeRheinKraanKeuringen.Models
{
    public class Opdracht
    {
        [Key]
        public int OpdrachtNummer { get; set; }
        public string WerkInstructie { get; set; }
        public DateTime DatumUitvoering { get; set; }
        public string KabelLeverancier { get; set; }
        public string Waarnemingen { get; set; }
        public byte[] Image { get; set; }
        public int BedrijfsUren { get; set; }
        public string AflegRedenen { get; set; }


        public ICollection<Kabelchecklist> Kabelchecklists { get; set; }
    }
}