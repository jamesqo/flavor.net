using System;
using System.Collections.Generic;
using System.IO;

namespace Flavor
{
    public static class Flv
    {
        public static FlvFile Parse(byte[] fileBytes)
            => Parse(new MemoryStream(fileBytes));

        public static FlvFile Parse(Stream fileStream)
            => new FlvReader(fileStream).ReadFlv();
    }
}
