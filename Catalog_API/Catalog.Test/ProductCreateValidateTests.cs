using Catalog.API.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Catalog.Test
{
    [TestClass]
    public class ProductCreateValidateTests
    {
        [TestMethod]
        public void ProductCreate_Should_Be_Valid()
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

            //Act
            var actual = pc.Validate();

            //Assert
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void ProductCreate_With_Id_Null()
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
                Id = null,
                ModelId = "001-001",
                Genders = new int[] { 0 },
                Name = "test",
                Season = "Winter",
                SeasonYear = "2018",
                Units = new Unit[] { unit }
            };

            //Act
            var actual = pc.Validate();

            //Assert
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(ProductCreate.IdCantBeNull.ToString(), actual.First());
        }

        [TestMethod]
        public void ProductCreate_With_1_Gender()
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

            var brand = new Brand
            {
                key = "B2",
                name = "B2-1",
                logoUrl = "logob2",
                logoLargeUrl = "largelogob2",
                brandFamily = new Brandfamily
                {
                    key = "BF2",
                    name = "BF2-1",
                    shopUrl = "bf2com"
                },
                shopUrl = "b2com"
            };

            var pc = new ProductCreate
            {
                Color = "red",
                Id = "001",
                ModelId = "001-001",
                Genders = new int[] {  },
                Name = "test",
                Season = "Winter",
                SeasonYear = "2018",
                Units = new Unit[] { unit },
                Brand = brand
            };

            //Act
            var actual = pc.Validate();

            //Assert
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(ProductCreate.OneGenderRequired.ToString(), actual.First());
        }
    }
}
