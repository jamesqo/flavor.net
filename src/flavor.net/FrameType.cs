using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public enum FrameType : byte
    {
        Key = 1,
        InterFrame = 2,
        DisposableInterFrame = 3,
        GeneratedKey = 4,
        Command = 5
    }
}
