using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public static class BinarySerializableExtensions
    {
        public static byte[] ToByteArray(this IBinarySerializable obj)
        {
            var bytes = new byte[obj.Size];
            var m = new MemoryStream(bytes);
            obj.CopyTo(m);
            return bytes;
        }
    }
}
