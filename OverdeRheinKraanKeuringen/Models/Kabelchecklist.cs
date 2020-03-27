using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OverdeRheinKraanKeuringen.Models
{
    public enum Waarde
    {
        [Display(Name = "Gering")]
        gering,
        [Display(Name = "Gemiddeld")]
        gemiddeld,
        [Display(Name = "Hoog")]
        hoog,
        [Display(Name = "Zeer hoog! Afleggen!")]
        zeer_hoog
    }

    public class Kabelchecklist
    {
        public Kabelchecklist()
        {
        }

        public Kabelchecklist(KabelchecklistViewModel kabelchecklistView)
        {
            this.KabelID = kabelchecklistView.KabelID;
            this.Breuk6D = kabelchecklistView.Breuk6D;
            this.Breuk30D = kabelchecklistView.Breuk30D;
            this.BeschadigingBuitenzijde = kabelchecklistView.BeschadigingBuitenzijde;
            this.BeschadigingRoestCorrosie = kabelchecklistView.BeschadigingRoestCorrosie;
            this.VerminderdeKabeldiameter = kabelchecklistView.VerminderdeKabeldiameter;
            this.PositieMeetpunten = kabelchecklistView.PositieMeetpunten;
            this.BeschadigingTotaal = kabelchecklistView.BeschadigingTotaal;
            this.TypeBeschadigingEnVervormingen = kabelchecklistView.TypeBeschadigingEnVervormingen;
            this.Opdrachtnummer = kabelchecklistView.Opdrachtnummer;
        }

        [Key]
        public int KabelID { get; set; }
        [Display(Name = "Breuk 6D")]
        [Range(0,int.MaxValue)]
        public int Breuk6D { get; set; }
        [Display(Name = "Breuk 30D")]
        [Range(0, int.MaxValue)]
        public int Breuk30D { get; set; }
        [Display(Name = "Beschadiging Buitenzijde")]
        public Waarde BeschadigingBuitenzijde { get; set; }
        [Display(Name = "Beschadiging Roest Corrosie")]
        public Waarde BeschadigingRoestCorrosie { get; set; }
        [Display(Name = "Verminderde Kabeldiameter")]
        [Range(0, int.MaxValue)]
        public int VerminderdeKabeldiameter { get; set; }
        [Display(Name = "Positie Meetpunten")]
        [Range(0, int.MaxValue)]
        public int PositieMeetpunten { get; set; }
        [Display(Name = "Beschadiging Totaal")]
        public Waarde BeschadigingTotaal { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Type Beschadiging en Vervormingen")]
        [StringLength(500, MinimumLength = 7)]
        public string TypeBeschadigingEnVervormingen { get; set; }

        [ForeignKey("Opdracht")]
        public int Opdrachtnummer { get; set; }
        public virtual Opdracht Opdracht { get; set; }
    }
    [NotMapped]
    public class KabelchecklistViewModel : Kabelchecklist
    {
        public KabelchecklistViewModel() { }
        public KabelchecklistViewModel(Kabelchecklist kabelchecklist)
        { 
            this.KabelID = kabelchecklist.KabelID;
            this.Breuk6D = kabelchecklist.Breuk6D;
            this.Breuk30D = kabelchecklist.Breuk30D;
            this.BeschadigingBuitenzijde = kabelchecklist.BeschadigingBuitenzijde;
            this.BeschadigingRoestCorrosie = kabelchecklist.BeschadigingRoestCorrosie;
            this.VerminderdeKabeldiameter = kabelchecklist.VerminderdeKabeldiameter;
            this.PositieMeetpunten = kabelchecklist.PositieMeetpunten;
            this.BeschadigingTotaal = kabelchecklist.BeschadigingTotaal;
            this.TypeBeschadigingEnVervormingen = kabelchecklist.TypeBeschadigingEnVervormingen;
            this.Opdrachtnummer = kabelchecklist.Opdrachtnummer;
        }
    }
}