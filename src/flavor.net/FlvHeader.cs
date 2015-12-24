using Be.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Flavor
{
    public class FlvHeader : IBinarySerializable
    {
        public const string Signature = "FLV";
        public const int Version = 1;
        public const int Size = 9;

        public HeaderFlags Flags { get; set; }

        public void CopyTo(Stream stream)
        {
            var writer = new BeBinaryWriter(stream);
            foreach (char c in Signature)
                writer.Write((byte)c);
            writer.Write((byte)Version);
            writer.Write((byte)Flags);
            writer.Write(Size);
        }

        int IBinarySerializable.Size => Size;
    }
}
