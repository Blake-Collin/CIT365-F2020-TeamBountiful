using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int ID { get; set; }

        [Display(Name = "Speaker:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Topic:")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\-0-9\s]*$")]
        [StringLength(50)]
        [Required]
        public string Topic { get; set; }

        public int MeetingID { get; set; }
    }
}
