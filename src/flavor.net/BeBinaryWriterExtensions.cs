using Be.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public static class BeBinaryWriterExtensions
    {
        public static void WriteInt24(this BeBinaryWriter writer, int value)
        {
            byte[] array =
            {
                (byte)(value >> 16),
                (byte)(value >> 8),
                (byte)value
            };
            writer.Write(array);
        }
    }
}
