using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OverdeRheinKraanKeuringen.Models
{
    public class Opdracht
    {
        public Opdracht() { }

        public Opdracht(OpdrachtViewModel opdrachtViewModel)
        {
            this.OpdrachtNummer = opdrachtViewModel.OpdrachtNummer;
            this.WerkInstructie = opdrachtViewModel.WerkInstructie;
            this.DatumUitvoering = opdrachtViewModel.DatumUitvoering;
            this.KabelLeverancier = opdrachtViewModel.KabelLeverancier;
            this.Waarnemingen = opdrachtViewModel.Waarnemingen;
            this.Image = opdrachtViewModel.Image;
            this.Bedrijfsuren = opdrachtViewModel.Bedrijfsuren;
            this.AflegRedenen = opdrachtViewModel.AflegRedenen;
        }

        [Key]
        public int OpdrachtNummer { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Werk Instructie")]
        [StringLength(500, MinimumLength = 7)]
        public string WerkInstructie { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum Uitvoering")]
        public DateTime DatumUitvoering { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Kabel Leverancier")]
        [StringLength(250, MinimumLength = 7)]
        public string KabelLeverancier { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Waarnemingen")]
        [StringLength(500, MinimumLength = 7)]
        public string Waarnemingen { get; set; }
        [Display(Name = "Handtekening")]
        public byte[] Image { get; set; }
        [Display(Name = "Bedrijfsuren")]
        public int Bedrijfsuren { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Afleg Redenen")]
        [StringLength(500, MinimumLength = 7)]
        public string AflegRedenen { get; set; }

        public virtual ICollection<Kabelchecklist> Kabelchecklists { get; set; }
    }
    [NotMapped]
    public class OpdrachtViewModel : Opdracht
    {
        public OpdrachtViewModel() { }
        public OpdrachtViewModel(Opdracht opdracht) 
        { 
            this.OpdrachtNummer = opdracht.OpdrachtNummer;
            this.WerkInstructie = opdracht.WerkInstructie;
            this.DatumUitvoering = opdracht.DatumUitvoering;
            this.KabelLeverancier = opdracht.KabelLeverancier;
            this.Waarnemingen = opdracht.Waarnemingen;
            this.Image = opdracht.Image;
            this.Bedrijfsuren = opdracht.Bedrijfsuren;
            this.AflegRedenen =  opdracht.AflegRedenen;
        }
    }
}