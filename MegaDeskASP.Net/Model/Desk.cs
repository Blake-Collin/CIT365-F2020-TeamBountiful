using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskASP.Model
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


        [Range(24,96)]
        [Required]
        public int deskWidth { get; set; }

        [Range(12,48)]
        [Required]
        public int deskDepth { get; set; }

        [Range(0, 7)]
        [Required]
        public int numOfDrawers { get; set; }

        [Required]
        public DeskMaterial material { get; set; }

    }
}
