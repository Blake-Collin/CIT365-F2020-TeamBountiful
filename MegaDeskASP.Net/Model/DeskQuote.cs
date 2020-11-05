using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskASP.Model
{
    public class DeskQuote
    {
        //Variables
        public int ID { get; set; }
        
        [Required]
        public Desk desk;
        
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Customer Name is Required")]
        public string customerName { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public decimal quoteAmount { get; }
        
        [Required]
        public int productionDays;

        [HiddenInput(DisplayValue = false)]
        public DateTime completionDate { get; set; }

     
    }
}
