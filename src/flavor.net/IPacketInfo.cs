using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public interface IPacketInfo
    {
        bool IsEncrypted { get; }
        PacketContent Content { get; }
    }
}
