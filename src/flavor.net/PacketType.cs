using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public struct PacketType : IBinarySerializable
    {
        private const int FilterMask = 0x20;
        private const int ContentMask = 0x1F;

        public PacketType(byte value)
        {
            this.AsByte = value;
        }

        public byte AsByte { get; }

        public PacketContent Content => 
            (PacketContent)(AsByte & ContentMask);

        public bool IsAudio => Content == PacketContent.Audio;
        public bool IsVideo => Content == PacketContent.Video;
        public bool IsMetadata => Content == PacketContent.Metadata;

        public bool IsEncrypted => (AsByte & FilterMask) != 0;

        int IBinarySerializable.Size => 1; // sizeof(byte)

        public static implicit operator PacketType(byte value)
            => new PacketType(value);

        public static implicit operator byte(PacketType type)
            => type.AsByte;

        public void CopyTo(Stream stream) =>
            stream.WriteByte(AsByte);
    }
}
