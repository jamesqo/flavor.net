using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public struct AudioInfo : IBinarySerializable
    {
        private const int SoundFormatMask = unchecked((int)0xFFFF0000);
        private const int SoundRateMask = 0xFF00;
        private const int SoundSizeMask = 0xF0;
        private const int SoundTypeMask = 0xF;

        public AudioInfo(byte value)
            : this()
        {
            this.AsByte = value;
        }

        public byte AsByte { get; }

        public SoundFormat SoundFormat =>
            (SoundFormat)(AsByte & SoundFormatMask >> 4);
        public bool Is16Bit =>
            (AsByte & SoundSizeMask) != 0;
        public bool IsStereo =>
            (AsByte & SoundTypeMask) != 0;


        public double SoundRate
        {
            get
            {
                switch (AsByte & SoundRateMask >> 2)
                {
                    case 0:
                        return 5.5;
                    case 1:
                        return 11d;
                    case 2:
                        return 22d;
                    case 3:
                        return 44d;
                    default:
                        throw new NotImplementedException("This shouldn't be possible.");
                }
            }
        }

        int IBinarySerializable.Size => 1; // sizeof(byte)

        public void CopyTo(Stream stream) =>
            stream.WriteByte(AsByte);

        public static implicit operator AudioInfo(byte value)
            => new AudioInfo(value);

        public static implicit operator byte(AudioInfo info)
            => info.AsByte;
    }
}
