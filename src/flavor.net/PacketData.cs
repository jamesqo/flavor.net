using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public abstract class PacketData : IBinarySerializable
    {
        public abstract int Size { get; }

        public abstract void CopyTo(Stream stream);

        // TODO: Should a declaration of 'byte[] RawData' be here too?

        public AudioData AsAudio() =>
            this as AudioData;

        public VideoData AsVideo() =>
            this as VideoData;

        public ScriptData AsMetadata() =>
            this as ScriptData;
    }
}
