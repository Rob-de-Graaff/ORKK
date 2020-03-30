using OverdeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverdeRheinKraanKeuringen.ViewModels
{
    public class OpdrachtViewModel : Opdracht
    {
        public IEnumerable<Opdracht> Opdrachten { get; set; }
        //public IEnumerable<Kabelchecklist> kabelchecklists { get; set; }
    }
}