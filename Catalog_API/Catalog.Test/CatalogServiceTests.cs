using AutoMapper;
using AutoMapper.Configuration;
using Catalog.API.Dto;
using Catalog.API.Infrastructure;
using Catalog.API.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Catalog.Test
{
    [TestClass]
    public class CatalogServiceTests
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var mappings = new MapperConfigurationExpression();
            mappings.AddProfile<MappingProfile>();
            Mapper.Initialize(mappings);
        }
        [TestMethod]
        public void GeneralStats_Should_Be_Zero()
        {
            //Arrange
            string uniqueDatabaseName = $"CatalogTestDb_{Guid.NewGuid()}";
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: uniqueDatabaseName)
                .Options;

            using (var context = new CatalogContext(options))
            {
                var service = new CatalogService(context);
                //Act
                var actual = service.GeneralStats();

                //Assert
                Assert.AreEqual(0, actual.ProductCount);
                Assert.AreEqual(0, actual.ProductsWithOneUnit.Count());
                Assert.AreEqual(0, actual.UnitCount);
            }
        }

        [TestMethod]
        public void GeneralStats_Should_Be_One()
        {
            //Arrange
            var unit = new Unit
            {
                available = true,
                id = "001-001-001",
                originalPrice = new Price { value = 100, currency = "EUR", formatted = "€100" },
                price = new Price { value = 100, currency = "EUR", formatted = "€100" },
                size = "38",
                stock = 5
            };
            var pc = new ProductCreate
            {
                Color = "red",
                Id = "001",
                ModelId = "001-001",
                Genders = new int[] { 0 },
                Name = "test",
                Season = "Winter",
                SeasonYear = "2018",
                Units = new Unit[] { unit }
            };

            string uniqueDatabaseName = $"CatalogTestDb_{Guid.NewGuid()}";
            var options = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: uniqueDatabaseName)
                .Options;

            using (var context = new CatalogContext(options))
            {
                var service = new CatalogService(context);
                //Act
                var validationResults = service.Create(pc);

                //Assert
                Assert.AreEqual(0, validationResults.Count());

                //Act
                var actual = service.GeneralStats();

                //Assert
                Assert.AreEqual(1, actual.ProductCount);
                Assert.AreEqual(1, actual.ProductsWithOneUnit.Count());
                Assert.AreEqual(1, actual.UnitCount);
            }
        }
    }
}
