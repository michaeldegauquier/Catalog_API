using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Dto.Interfaces
{
    interface IHasValidation
    {
        IEnumerable<string> Validate();
    }
}
