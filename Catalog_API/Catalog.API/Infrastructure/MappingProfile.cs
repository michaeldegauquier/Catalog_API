using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping Models > Dto
            CreateMap<Models.Product, Dto.Product>();
            CreateMap<Models.Unit, Dto.Unit>();
            CreateMap<Models.Price, Dto.Price>();
            CreateMap<Models.Brand, Dto.Brand>();
            CreateMap<Models.Brandfamily, Dto.Brandfamily>();
            CreateMap<Dto.ProductCreate, Models.Product>();
            CreateMap<Dto.Unit, Models.Unit>();
            CreateMap<Dto.Price, Models.Price>();
            CreateMap<Dto.Brand, Models.Brand>();
            CreateMap<Dto.Brandfamily, Models.Brandfamily>();
        }
    }
}
