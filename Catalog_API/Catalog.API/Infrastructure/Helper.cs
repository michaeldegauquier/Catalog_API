using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure
{
    public static class Helper
    {
        public static bool IsEmpty<T>(this T[] array)
        {
            if (array.Length == 0 || array == null)
            {
                return true;
            }
            return false;
        }
    }
}
