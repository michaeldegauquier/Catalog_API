using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    [Owned]
    public class Price
    {
        public string Currency { get; set; }
        public Single Value { get; set; }
        public string Formatted { get; set; }
    }
}
