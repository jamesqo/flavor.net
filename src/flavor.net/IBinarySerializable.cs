using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public interface IBinarySerializable
    {
        int Size { get; }
        void CopyTo(Stream stream);
    }
}
