using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Models
{
    public class DeskMaterial
    {
        public int ID { get; set; }

        [Display(Name = "Desk Material")]
        public string DeskMaterialName { get; set; }
        public decimal DeskMaterialPrice { get; set; }
        
        
    }
}
