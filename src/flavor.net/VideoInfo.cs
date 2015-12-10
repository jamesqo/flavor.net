using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flavor
{
    public class VideoInfo
    {
        public VideoInfo(byte value)
        {
            this.AsByte = value;
        }

        public byte AsByte { get; }

        public FrameType FrameType;
        public CodecId CodecId;
    }
}
