using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Models
{
    public class DeskQuote
    {
        //Variables
        public int ID { get; set; }

        [BindProperty]
        public Desk desk { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Customer Name")]
        public string customerName { get; set; }
        
        [Display(Name = "Quote Amount"), DataType(DataType.Currency)]
        public decimal quoteAmount { get; set; }

        [Display(Name = "Completion Date")]
        public Nullable<DateTime> completionDate { get; set; }        

        public Nullable<DateTime> startDate { get; set; }

        [BindProperty]
        [Display(Name = "Rush Shipping")]
        public RushShipping RushShipping { get; set; }

     
    }
}
