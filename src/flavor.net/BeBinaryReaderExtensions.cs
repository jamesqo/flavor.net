using Be.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public static class BeBinaryReaderExtensions
    {
        public static int ReadInt24(this BeBinaryReader reader)
        {
            var array = reader.ReadBytes(3);
            return array[0] << 16 | array[1] << 8 | array[2];
        }
    }
}
