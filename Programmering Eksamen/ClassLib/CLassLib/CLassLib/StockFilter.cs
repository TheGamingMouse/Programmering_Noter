using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLassLib
{
    public class StockFilter
    {
        public int? StockLevel { get; set; }
    }
    public record Filter (int? StockLevel);
}
