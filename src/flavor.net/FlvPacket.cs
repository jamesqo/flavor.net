using Be.IO;
using Flavor.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace Flavor
{
    public class FlvPacket : IBinarySerializable
    {
        public const int HeaderSize = 11;
        public const int StreamId = 0;

        public FlvPacket(PacketData data)
        {
            this.Data = data;
        }

        public PacketType Type { get; set; }
        public int TimeStamp { get; set; }
        public PacketData Data { get; }

        public int Size =>
            HeaderSize + Data.Size;

        public void CopyTo(Stream stream)
        {
            var writer = new BeBinaryWriter(stream);
            writer.Write(Type.AsByte);
            writer.WriteInt24(Data.Size);

            // Time stamps are read with the high
            // byte being the last read (e.g. 
            // 0x11223344 is serialized as 
            // 0x44112233).
            const int HighMask = unchecked((int)0xFF000000);
            int lo = TimeStamp & ~HighMask;
            byte hi = (byte)(TimeStamp & HighMask);
            writer.WriteInt24(lo);
            writer.Write(hi);

            writer.WriteInt24(StreamId);
            Data.CopyTo(stream);
        }
    }
}
