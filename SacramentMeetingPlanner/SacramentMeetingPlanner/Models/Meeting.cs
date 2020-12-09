using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }

        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Display(Name = "Conducting:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Required]
        public string Conducting { get; set; }

        [Display(Name = "Opening Hymn:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\-0-9\s]*$")]
        [StringLength(50)]
        [Required]
        public string OpeningHymn { get; set; }

        [Display(Name = "Invocation:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Required]
        public string Invocation { get; set; }

        [Display(Name = "Sacrament Hymn:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\-0-9\s]*$")]
        [StringLength(50)]
        [Required]
        public string SacramentHymn { get; set; }

        [Display(Name = "Sacrament Prayer:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Required]
        public string SacramentPrayer { get; set; }

        public ICollection<SpeakerEnrollment> Speakers { get; set; }

        [Display(Name = "Closing Hymn:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\-0-9\s]*$")]
        [StringLength(50)]
        [Required]
        public string ClosingHymn { get; set; }

        [Display(Name = "Benediction:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Required]
        public string Benediction { get; set; }
    }
}
