using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskASP.Model
{
    public class RushShipping
    {
        public int ID { get; set; }
        public int MaxSize { get; set; }
        public int RushDays { get; set; }
        public decimal RushPrice { get; set; }
    }
}
