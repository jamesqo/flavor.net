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

        public override int Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void CopyTo(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
