using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Catalog.API.Dto
{
    public class Price
    {
        public string currency { get; set; }
        public Single value { get; set; }
        public string formatted { get; set; }
    }
}
