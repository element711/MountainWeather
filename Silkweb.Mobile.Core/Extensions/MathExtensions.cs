using System;
using System.Collections.Generic;
using System.Linq;

namespace Silkweb.Mobile.Core.Extensions
{
    public static class MathExtensions
    {
        public static int Mode(this IEnumerable<int> values)
        {
            return values
                .GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

    }
}

