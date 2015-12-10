using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public class VideoData : PacketData
    {
        public VideoInfo VideoInfo;
        public byte[] RawData;
    }
}
