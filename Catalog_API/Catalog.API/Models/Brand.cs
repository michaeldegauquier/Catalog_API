using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Brand
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string LogoLargeUrl { get; set; }
        [ForeignKey("BrandfamilyKey")]
        public Brandfamily BrandFamily { get; set; }
        public string ShopUrl { get; set; }
    }
}
