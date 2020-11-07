using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Models
{
    public class RushShipping
    {
        public int ID { get; set; }

        [Display(Name = "Shipping Method")]
        public string RushName { get; set; }
        public decimal RushPrice { get; set; }
    }
}
