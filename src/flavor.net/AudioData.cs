using Flavor.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public class AudioData : PacketData
    {
        public AudioInfo AudioInfo { get; set; }
        public byte[] RawData { get; set; }

        public override int Size =>
            1 + RawData.Length; // sizeof(AudioInfo)

        public override void CopyTo(Stream stream)
        {
            AudioInfo.CopyTo(stream);
            stream.Write(RawData);
        }
    }
}
