using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDeskWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskWebContext(
                serviceProvider.GetRequiredService<DbContextOptions<MegaDeskWebContext>>()))
            {
                //DeskMaterials

                if(!context.DeskMaterial.Any())
                {
                    context.DeskMaterial.AddRange(
                        new DeskMaterial
                        {
                            DeskMaterialName = "Oak",
                            DeskMaterialPrice = 200,
                        },
                        new DeskMaterial
                        {
                            DeskMaterialName = "Laminate",
                            DeskMaterialPrice = 100,
                        },
                        new DeskMaterial
                        {
                            DeskMaterialName = "Pine",
                            DeskMaterialPrice = 50,
                        },
                        new DeskMaterial
                        {
                            DeskMaterialName = "Rosewood",
                            DeskMaterialPrice = 300,
                        },
                        new DeskMaterial
                        {
                            DeskMaterialName = "Veneer",
                            DeskMaterialPrice = 125,
                        }
                        );
                }


                //RushShipping
                if(!context.RushShipping.Any())
                {
                    context.RushShipping.AddRange(
                        new RushShipping
                        {                            
                            RushName = "3 Day Min",
                            RushPrice = 60
                        },
                        new RushShipping
                        {
                            RushName = "3 Day Med",
                            RushPrice = 70
                        },
                        new RushShipping
                        {
                            RushName = "3 Day Max",
                            RushPrice = 80
                        },
                        new RushShipping
                        {
                            RushName = "5 Day Min",
                            RushPrice = 40
                        },
                        new RushShipping
                        {
                            RushName = "5 Day Med",
                            RushPrice = 50
                        },
                        new RushShipping
                        {
                            RushName = "5 Day Max",
                            RushPrice = 60
                        },
                        new RushShipping
                        {
                            RushName = "7 Day Min",
                            RushPrice = 30
                        },
                        new RushShipping
                        {
                            RushName = "7 Day Med",
                            RushPrice = 35
                        },
                        new RushShipping
                        {
                            RushName = "7 Day Max",
                            RushPrice = 40
                        }
                        );
                }


                //DeskQuotes & Desks Here

                if(!context.DeskQuote.Any())
                {

                }

                context.SaveChanges();
            }
        }
    }
}
