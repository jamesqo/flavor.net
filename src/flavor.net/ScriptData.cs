using Flavor.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public class ScriptData : PacketData
    {
        public byte[] RawData { get; set; }

        public override int Size =>
            RawData.Length;

        public override void CopyTo(Stream stream) =>
            stream.Write(RawData);
    }
}
