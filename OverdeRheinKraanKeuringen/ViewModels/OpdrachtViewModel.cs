using OverdeRheinKraanKeuringen.Models;
using System.Collections.Generic;

namespace OverdeRheinKraanKeuringen.ViewModels
{
    public class OpdrachtViewModel : Opdracht
    {
        public IEnumerable<Opdracht> Opdrachten { get; set; }
        //public IEnumerable<Kabelchecklist> kabelchecklists { get; set; }
    }
}