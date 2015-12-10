using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public struct PacketType : IPacketInfo
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

        public bool IsEncrypted => (AsByte & FilterMask) != 0;

        public static implicit operator PacketType(byte value)
            => new PacketType(value);

        public static explicit operator byte(PacketType type)
            => type.AsByte;
    }
}
