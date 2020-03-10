using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class ProductGender
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
