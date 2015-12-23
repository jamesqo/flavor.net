using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Flavor.Tests.Helpers
{
    internal static class ByteArrayExtensions
    {
        public static Stream AsStream(this byte[] array) =>
            new MemoryStream(array);
    }
}
