using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public struct AudioInfo
    {
        public AudioInfo(byte value)
        {
            this.AsByte = value;
        }

        public byte AsByte { get; }

        public SoundFormat SoundFormat;
        public SoundRate SoundRate;
        public bool Is16Bit;
        public bool IsStereo;
    }
}
