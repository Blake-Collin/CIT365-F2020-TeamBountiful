﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Data
{
    public class MegaDeskWebContext : DbContext
    {
        public MegaDeskWebContext (DbContextOptions<MegaDeskWebContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWeb.Models.DeskQuote> DeskQuote { get; set; }

        public DbSet<MegaDeskWeb.Models.Desk> Desk { get; set; }

        public DbSet<MegaDeskWeb.Models.RushShipping> RushShipping { get; set; }

        public DbSet<MegaDeskWeb.Models.DeskMaterial> DeskMaterial { get; set; }
    }
}
