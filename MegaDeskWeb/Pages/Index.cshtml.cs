using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace MegaDeskWeb.Pages
{
    public class IndexModel : PageModel
    {
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentString, string searchString)
        {
            if(currentString != null)
            {
                SearchString = currentString;
            }                
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if(searchString == null)
            {
                searchString = currentString;
            }
            SearchString = searchString;

            IQueryable<DeskQuote> deskQuoteIQ = from d in _context.DeskQuote select d;

            DeskQuote = await deskQuoteIQ.Include(d => d.desk).Include(d => d.RushShipping).ToListAsync();
            var names = from m in _context.DeskQuote select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                names = names.Where(s => s.customerName.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    names = names.OrderByDescending(d => d.customerName);
                    break;
                case "Date":
                    names = names.OrderBy(d => d.completionDate);
                    break;
                case "date_desc":
                    names = names.OrderByDescending(d => d.completionDate);
                    break;
                default:
                    names = names.OrderBy(d => d.customerName);
                    break;
            }

            

            DeskQuote = await names.ToListAsync();
        }
    }
}
