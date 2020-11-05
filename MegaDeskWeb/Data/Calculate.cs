using MegaDeskWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Data
{
    public class Calculate
    {
        public static DeskQuote PopulateQuote(DeskQuote _Quote, int _ship, int _material, MegaDeskWebContext _context)
        {
            _Quote.desk.material = _context.DeskMaterial.Where(s => s.ID == _material).FirstOrDefault();
            decimal surfaceArea = _Quote.desk.deskWidth * _Quote.desk.deskDepth;
            decimal price = 200;                        

            //material price
            price += _Quote.desk.material.DeskMaterialPrice;


            //Drawer Price
            price += _Quote.desk.numOfDrawers * 50;

            //Surface Area over 1000
            if(surfaceArea > 1000)
            {
                price += surfaceArea - 1000;
            }

            //Shipping Field
            switch (_ship)
            {
                case 3:
                    if(_Quote.startDate == null)
                    {
                        _Quote.completionDate = DateTime.Now.AddDays(3);
                        _Quote.startDate = DateTime.Now;
                    }
                    else
                    {
                        _Quote.completionDate = _Quote.startDate.Value.AddDays(3);
                    }
                    
                    if (surfaceArea < 1000)
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "3 Day Min").SingleOrDefault();
                    }
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "3 Day Med").SingleOrDefault();
                    }
                    else
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "3 Day Max").SingleOrDefault();
                    }
                    break;
                case 5:
                    if (_Quote.startDate == null)
                    {
                        _Quote.completionDate = DateTime.Now.AddDays(5);
                        _Quote.startDate = DateTime.Now;
                    }
                    else
                    {
                        _Quote.completionDate = _Quote.startDate.Value.AddDays(5);
                    }
                    if (surfaceArea < 1000)
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "5 Day Min").SingleOrDefault();
                    }
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "5 Day Med").SingleOrDefault();
                    }
                    else
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "5 Day Max").SingleOrDefault();
                    }
                    break;
                case 7:
                    if (_Quote.startDate == null)
                    {
                        _Quote.completionDate = DateTime.Now.AddDays(7);
                        _Quote.startDate = DateTime.Now;
                    }
                    else
                    {
                        _Quote.completionDate = _Quote.startDate.Value.AddDays(7);
                    }
                    if (surfaceArea < 1000)
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "7 Day Min").SingleOrDefault();
                    }
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "7 Day Med").SingleOrDefault();
                    }
                    else
                    {
                        _Quote.RushShipping = _context.RushShipping.Where(s => s.RushName == "7 Day Max").SingleOrDefault();
                    }
                    break;

                default:
                    if (_Quote.startDate == null)
                    {
                        _Quote.completionDate = DateTime.Now.AddDays(14);
                        _Quote.startDate = DateTime.Now;
                    }
                    else
                    {
                        _Quote.completionDate = _Quote.startDate.Value.AddDays(14);
                    }                    
                    _Quote.RushShipping = new RushShipping { ID = 0, RushName = "Standard", RushPrice = 0 };
                    break;
            }

            price += _Quote.RushShipping.RushPrice;
            _Quote.quoteAmount = price;
            DeskQuote cQuote = _Quote;
            return cQuote;
        }
    }
}
