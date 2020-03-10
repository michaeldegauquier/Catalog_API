using Catalog.API.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Infrastructure;

namespace Catalog.API.Dto
{
    public class ProductCreate: IHasValidation
    {
        public string Id { get; set; }
        public string ModelId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Season { get; set; }
        public string SeasonYear { get; set; }
        public int[] Genders { get; set; }
        public Unit[] Units { get; set; }
        public Brand Brand { get; set; }

        public static ValidationMessage IdCantBeNull
        {
            get
            {
                return new ValidationMessage { Message = "Id mag niet null zijn!" };
            }
        }
        public static ValidationMessage OneGenderRequired
        {
            get
            {
                return new ValidationMessage { Message = "Elk product moet minstens 1 gender hebben!" };
            }
        }

        public static ValidationMessage OneUnitRequired
        {
            get
            {
                return new ValidationMessage { Message = "Elk product moet minstens 1 unit hebben!" };
            }
        }

        public IEnumerable<string> Validate()
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id))
            {
                yield return IdCantBeNull.ToString();
            }

            if (Genders.IsEmpty())
            {
                yield return OneGenderRequired.ToString();
            } 

            if (Units.IsEmpty())
            {
                yield return OneUnitRequired.ToString();
            }
        }
    }
}
