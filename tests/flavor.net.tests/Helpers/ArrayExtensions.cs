using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flavor.Tests.Helpers
{
    internal static class ArrayExtensions
    {
        public static bool SequenceEqual<T>(this T[] here, T[] there) =>
            here.SequenceEqual(there, null);

        public static bool SequenceEqual<T>(this T[] here, T[] there, IEqualityComparer<T> comparer)
        {
            if (here.Length != there.Length)
                return false;
            if (comparer == null)
                comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < here.Length; i++)
            {
                if (!comparer.Equals(here[i], there[i]))
                    return false;
            }

            return true;
        }
    }
}
