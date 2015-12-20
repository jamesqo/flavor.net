using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor.Helpers
{
    internal static class EnumerableExtensions
    {
        public static T[] AsArray<T>(this IEnumerable<T> source)
            => source as T[] ?? source.ToArray();

        public static List<T> AsList<T>(this IEnumerable<T> source)
            => source as List<T> ?? source.ToList();
    }
}
