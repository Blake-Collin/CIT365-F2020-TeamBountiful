using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskASP.Model;

namespace MegaDeskASP.Data
{
    public class MegaDeskASPContext : DbContext
    {
        public MegaDeskASPContext (DbContextOptions<MegaDeskASPContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskASP.Model.DeskQuote> DeskQuote { get; set; }
    }
}
