using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ModelId { get; set; }
        public string ShopUrl { get; set; }
        public string Color { get; set; }
        public bool Available { get; set; }
        public string Season { get; set; }
        public string SeasonYear { get; set; }
        public DateTime ActivationDate { get; set; }
        public ICollection<ProductGender> ProductGenders { get; set; }
        public List<Unit> Units { get; set; }
        public Brand Brand { get; set; }
    }
}
