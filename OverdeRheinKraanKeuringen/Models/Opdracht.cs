﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OverdeRheinKraanKeuringen.Models
{
    public class Opdracht
    {
        [Key]
        public int opdrachtNummer { get; set; }
        public string werkIntrustie { get; set; }
        public DateTime DatumUitvoering { get; set; }
        public string kabelLeverancier { get; set; }
        public string Waarnemingen { get; set; }
        public byte[] Image { get; set; }
        public int bedrijfsUren { get; set; }
        public string aflegRedenen { get; set; }
    }
}