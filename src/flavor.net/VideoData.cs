using Flavor.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public class VideoData : PacketData
    {
        public VideoInfo VideoInfo { get; set; }
        public byte[] RawData { get; set; }

        public override int Size =>
            1 + RawData.Length; // sizeof(VideoInfo)

        public override void CopyTo(Stream stream)
        {
            VideoInfo.CopyTo(stream);
            stream.Write(RawData);
        }
    }
}
