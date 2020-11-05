using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskWeb.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public int matieralID { get; set; }
        [BindProperty]
        public int shipID { get; set; }
        public SelectList deskMaterials { get; set; }
        public List<SelectListItem> shipping { get; set; }

        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public CreateModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateMaterials();
            PopulateShipping();
            return Page();
        }

        private void PopulateShipping()
        {
            shipping = new List<SelectListItem>()
            {
                new SelectListItem{Value="14", Text="Standard Shipping" },
                new SelectListItem{Value="3", Text="3-Day Shipping" },
                new SelectListItem{Value="5", Text="5-Day Shipping" },
                new SelectListItem{Value="7", Text="7-Day Shipping" }
            };
        }

        private void PopulateMaterials()
        {
            var materials = from x in _context.DeskMaterial select x;
            deskMaterials = new SelectList(materials.AsEnumerable<DeskMaterial>(), nameof(DeskMaterial.ID), nameof(DeskMaterial.DeskMaterialName));
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Calculation funciton callout to generate price and completion date
            DeskQuote = Calculate.PopulateQuote(DeskQuote, shipID, matieralID, _context);
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
