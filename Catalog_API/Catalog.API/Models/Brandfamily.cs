using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Brandfamily
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public string ShopUrl { get; set; }
    }
}
