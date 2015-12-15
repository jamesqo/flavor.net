using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor.Helpers
{
    internal static class StreamExtensions
    {
        public static void Write(this Stream stream, byte[] buffer)
            => stream.Write(buffer, 0, buffer.Length);
    }
}
