using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Models
{
    //Limit ourselves to these types

    //public enum DeskMaterial
    //{
    //    Pine,
    //    Laminate,
    //    Veneer,
    //    Oak,
    //    Rosewood
    //}
    
    public class Desk
    {
        public int ID { get; set; }


        [Display(Name = "Desk Width"),Range(24,96)]
        [Required]
        public int deskWidth { get; set; }

        [Display(Name = "Desk Depth"), Range(12,48)]
        [Required]
        public int deskDepth { get; set; }

        [Display(Name = "Number of Drawers"), Range(0, 7)]
        [Required]
        public int numOfDrawers { get; set; }

        [Display(Name = "Desk Material")]
        [BindProperty]        
        public DeskMaterial material { get; set; }

    }
}
