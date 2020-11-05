using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public int matieralID { get; set; }
        [BindProperty]
        public int shipID { get; set; }
        public SelectList deskMaterials { get; set; }
        public List<SelectListItem> shipping { get; set; }        
        public int SelectedMaterial { get; set; }
        public int SelectedShipping { get; set; }

        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public EditModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            

            DeskQuote = await _context.DeskQuote
                .Include(d => d.desk)
                .Include(d => d.desk.material)
                .Include(d => d.RushShipping)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }

            PopulateShipping();
            PopulateMaterials();
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

            string sTemp = DeskQuote.RushShipping.RushName.Substring(0,1);
            int iTemp;
            if(int.TryParse(sTemp, out iTemp))
            {
                shipID = iTemp;
            }            
        }

        private void PopulateMaterials()
        {
            var materials = from x in _context.DeskMaterial select x;
            deskMaterials = new SelectList(materials.AsEnumerable<DeskMaterial>(), nameof(DeskMaterial.ID), nameof(DeskMaterial.DeskMaterialName));
            int count = 0;
           
            foreach(DeskMaterial desk in deskMaterials.Items)
            {
                if (desk.ID == DeskQuote.desk.material.ID)
                {
                    matieralID = desk.ID;
                    break;
                }
                count++;
            }
        }

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
            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.ID == id);
        }
    }
}
