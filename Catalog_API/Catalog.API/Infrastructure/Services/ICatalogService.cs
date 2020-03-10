using Catalog.API.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Services
{
    public interface ICatalogService
    {
        IEnumerable<string> Create(ProductCreate productCreate);

        Product Get(string id);

        List<Product> List(int page = 1);
        CatalogStats GeneralStats();

        Task<CatalogStats> GeneralStatsAsync();
    }
}
