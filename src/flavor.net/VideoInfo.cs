using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public struct VideoInfo : IBinarySerializable
    {
        private const int FrameTypeMask = unchecked((int)0xFFFF0000);
        private const int CodecIdMask = 0xFFFF;

        public VideoInfo(byte value)
            : this()
        {
            this.AsByte = value;
        }

        public byte AsByte { get; }

        public FrameType FrameType =>
            (FrameType)(AsByte & FrameTypeMask >> 4);
        public CodecId CodecId =>
            (CodecId)(AsByte & CodecIdMask);

        int IBinarySerializable.Size => 1; // sizeof(byte)

        public void CopyTo(Stream stream) =>
            stream.WriteByte(AsByte);

        public static implicit operator VideoInfo(byte value)
            => new VideoInfo(value);

        public static implicit operator byte(VideoInfo info)
            => info.AsByte;
    }
}
