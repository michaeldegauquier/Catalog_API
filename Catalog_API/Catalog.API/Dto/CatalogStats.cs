using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Dto
{
    public class CatalogStats
    {
        public int ProductCount { get; set; }
        public int UnitCount { get; set; }
        public IEnumerable<string> ProductsWithOneUnit { get; set; }
    }
}
