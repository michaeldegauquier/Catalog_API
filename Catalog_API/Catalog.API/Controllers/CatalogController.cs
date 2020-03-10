using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Dto;
using Catalog.API.Infrastructure;
using Catalog.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Dto
{
    [Route("v2/api")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        //CatalogContext catalogContext;
        ICatalogService catalogService;

        /*
        public CatalogController(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        */
     
        public CatalogController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }
        
        
        [HttpPost("Catalog")]
        public ActionResult Create(Dto.ProductCreate productCreate)
        {
            var validationResults = catalogService.Create(productCreate);
            if (validationResults.Count() > 0)
            {
                return BadRequest(validationResults);
            }

            return Ok();
        }


        [HttpGet("catalog/{id}")]
        public Dto.Product Get(string id)
        {
            return catalogService.Get(id);
        }

        [HttpGet("catalog/list/")]
        public List<Dto.Product> List(int page = 1)
        {
            return catalogService.List(page);
        }

        [HttpGet("catalog/generalstats/")]
        public Task<CatalogStats> CatalogStats()
        {
            return catalogService.GeneralStatsAsync();
        }
        


        /*
        [HttpGet("GeneralStats")]
        public async Task<CatalogStats> GeneralStats(int page = 1)
        {
            return await Task.Run(() => catalogService.Gen);
        }
        */

        //------------Niet meer nodig------------

        /*
        [HttpGet("catalog/list/")]
        public List<Dto.Product> List(int page = 1)
        {
            List<Models.Product> listProductModels = new List<Models.Product>();

            listProductModels = catalogContext.Product
                .Include(x => x.ProductGenders).ThenInclude(x => x.Gender)
                .Include(x => x.Units).ThenInclude(x => x.Price)
                .Include(x => x.Units).ThenInclude(x => x.OriginalPrice)
                .Skip((page - 1) * 10)
                .Take(page * 10)
                .ToList();

            return listProductModels.Select(x => Map(x)).ToList();
        }
        */

        /*
        private Dto.Product Map(Models.Product product)
        {
            var productDto = Mapper.Map<Models.Product, Dto.Product>(product);
            var genders = new List<string>();
            foreach (var productGender in product.ProductGenders)
            {
                genders.Add(productGender.Gender.Name);
            }
            productDto.genders = genders.ToArray();
            return productDto;
        }
        */

        /*
        // GET api/values
        [HttpGet("catalog/{id}/")]
        public Dto.Product Get(string id)
        {
            Models.Product product = catalogContext.Product
                .Include(x => x.ProductGenders).ThenInclude(x => x.Gender)
                .Include(x => x.Units).ThenInclude(x => x.Price)
                .Include(x => x.Units).ThenInclude(x => x.OriginalPrice)
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

            productDto.units = dtoUnits.ToArray();
            return productDto;
        }
        */

        /*
        [HttpPost("Catalog")]
        public ActionResult Create(Dto.ProductCreate productCreate)
        {
            //Validate before save to db
            var validationResults = productCreate.Validate();
            if (validationResults.Count() > 0)
            {
                return BadRequest(validationResults);
            }

            //Map Dto to Models
            var productModel = Mapper.Map<Dto.ProductCreate, Models.Product>(productCreate);

            //Add productModel
            catalogContext.Add(productModel);

            //Add productGender
            foreach(var genderId in productCreate.Genders)
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
            return Ok();
        }
        */
    }
}
