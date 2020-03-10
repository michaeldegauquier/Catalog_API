using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Services
{
    public class CatalogService : ICatalogService
    {
        private CatalogContext catalogContext;

        public CatalogService(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }


        //[HttpPost("Catalog")]
        public IEnumerable<string> Create(ProductCreate productCreate)
        {
            //Validate before save to db
            var validationResults = productCreate.Validate();
            if (validationResults.Count() > 0)
            {
                return validationResults;
            }

            //Map Dto to Models
            var productModel = Mapper.Map<Dto.ProductCreate, Models.Product>(productCreate);

            //Add productModel
            catalogContext.Add(productModel);

            //Add productGender
            foreach (var genderId in productCreate.Genders)
            {
                var productGender = new Models.ProductGender
                {
                    GenderId = genderId,
                    ProductId = productModel.Id
                };
                catalogContext.ProductGender.Add(productGender);
            }

            //Commit changes to db
            catalogContext.SaveChanges();
            return validationResults;
        }

        //[HttpGet("catalog/{id}/")]
        public Product Get(string id)
        {
            Models.Product product = catalogContext.Product
                .Include(x => x.ProductGenders).ThenInclude(x => x.Gender)
                .Include(x => x.Units).ThenInclude(x => x.Price)
                .Include(x => x.Units).ThenInclude(x => x.OriginalPrice)
                .Include(x => x.Brand).ThenInclude(x => x.BrandFamily)
                .Single(x => x.Id == id);

            Dto.Product productDto = new Dto.Product
            {
                id = product.Id,
                modelId = product.ModelId,
                name = product.Name,
                shopUrl = product.ShopUrl,
                color = product.Color,
                available = product.Available,
                season = product.Season,
                seasonYear = product.SeasonYear,
                activationDate = product.ActivationDate
            };

            productDto.genders = product.ProductGenders.Select(x => x.Gender.Name).ToArray();

            var dtoUnits = new List<Dto.Unit>();
            foreach (var unit in product.Units)
            {
                var dtoUnit = new Dto.Unit
                {
                    available = unit.Available,
                    id = unit.Id,
                    price = new Price
                    {
                        currency = unit.Price.Currency,
                        value = unit.Price.Value,
                        formatted = unit.Price.Formatted
                    },
                    originalPrice = new Price
                    {
                        currency = unit.OriginalPrice.Currency,
                        value = unit.OriginalPrice.Value,
                        formatted = unit.OriginalPrice.Formatted
                    },
                    size = unit.Size,
                    stock = unit.Stock
                };
                dtoUnits.Add(dtoUnit);
            }

            Dto.Brand brandDto = new Dto.Brand
            {
                key = product.Brand.Key,
                name = product.Brand.Name,
                logoUrl = product.Brand.LogoUrl,
                logoLargeUrl = product.Brand.LogoLargeUrl,
                brandFamily = new Brandfamily
                {
                    key = product.Brand.BrandFamily.Key,
                    name = product.Brand.BrandFamily.Name,
                    shopUrl = product.Brand.BrandFamily.ShopUrl
                },
                shopUrl = product.Brand.ShopUrl
            };

            productDto.units = dtoUnits.ToArray();
            productDto.brand = brandDto;
            return productDto;
        }

        //[HttpGet("catalog/list/")]
        public List<Product> List(int page = 1)
        {
            List<Models.Product> listProductModels = new List<Models.Product>();

            listProductModels = catalogContext.Product
                .Include(x => x.ProductGenders).ThenInclude(x => x.Gender)
                .Include(x => x.Units).ThenInclude(x => x.Price)
                .Include(x => x.Units).ThenInclude(x => x.OriginalPrice)
                .Include(x => x.Brand).ThenInclude(x => x.BrandFamily)
                .Skip((page - 1) * 10)
                .Take(page * 10)
                .ToList();

            return listProductModels.Select(x => Map(x)).ToList();
        }

        /*
        [HttpGet("catalog/generalstats/")]
        public CatalogStats GeneralStats(int page = 1)
        {
            CatalogStats cs = new CatalogStats();

            cs.ProductCount = List(page).Select(x => x.id).Count(); ;

            cs.UnitCount = List(page).SelectMany(x => x.units).Count();

            cs.ProductsWithOneUnit = from iets in List(page)
                                     where iets.units.Length == 1
                                     select iets.id;

            return cs;
        }
        */


        /*
        //[HttpGet("catalog/generalstats/")]
        public async Task<CatalogStats> GeneralStats(int page = 1)
        {
            CatalogStats cs = new CatalogStats();

            cs.ProductCount = List(page).Select(x => x.id).Count(); ;

            cs.UnitCount = List(page).SelectMany(x => x.units).Count();

            cs.ProductsWithOneUnit = from iets in List(page)
                                     where iets.units.Length == 1
                                     select iets.id;

            return await Task.Run(() => cs);
        }
        */

        public CatalogStats GeneralStats()
        {
            var stats = new CatalogStats();
            stats.ProductCount = catalogContext.Product.Count();
            stats.UnitCount = catalogContext.Product.SelectMany(x => x.Units).Count();
            stats.ProductsWithOneUnit = catalogContext.Product.Where(x => x.Units.Count() == 1).Select(x => x.Id).ToList();
            return stats;
        }

        public async Task<CatalogStats> GeneralStatsAsync()
        {
            var stats = new CatalogStats();
            stats.ProductCount = await catalogContext.Product.CountAsync();
            stats.UnitCount = await catalogContext.Product.SelectMany(x => x.Units).CountAsync();
            stats.ProductsWithOneUnit = await catalogContext.Product.Where(x => x.Units.Count() == 1).Select(x => x.Id).ToListAsync();
            return stats;
        }


        private Dto.Product Map(Models.Product product)
        {
            /*
            var productDto = Mapper.Map<Models.Product, Dto.Product>(product);
            var genders = new List<string>();
            foreach (var productGender in product.ProductGenders)
            {
                genders.Add(productGender.Gender.Name);
            }
            productDto.genders = genders.ToArray();
            return productDto;
            */
            var productDto = Mapper.Map<Models.Product, Dto.Product>(product);
            productDto.genders = product.ProductGenders.Select(x => x.Gender.Name).ToArray();
            return productDto;
        }
    }
}
