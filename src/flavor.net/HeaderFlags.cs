using System;
using System.Collections.Generic;

namespace Flavor
{
    [Flags]
    public enum HeaderFlags : byte
    {
        Video = 0x05,
        Audio = 0x04
    }
}
