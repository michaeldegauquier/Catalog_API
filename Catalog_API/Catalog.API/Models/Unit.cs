using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Unit
    {
        public string Id { get; set; }
        public string Size { get; set; }
        public Price Price { get; set; }
        public Price OriginalPrice { get; set; }
        public bool Available { get; set; }
        public int Stock { get; set; }
        public Product Product { get; set; }
    }
}