using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public enum PacketContent : byte
    {
        Audio = 8,
        Video = 9,
        Metadata = 18
    }
}
