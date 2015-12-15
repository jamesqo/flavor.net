using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public enum SoundFormat : byte
    {
        LinearPcm = 0,
        Adpcm = 1,
        Mp3 = 2,
        LinearPcmLittle = 3,
        Mono16 = 4,
        Mono8 = 5,
        Nellymoser = 6,
        ALogarithmicPcm = 7,
        MuLogarithmicPcm = 8,
        Aac = 10,
        Speex = 11,
        Mp38 = 14,
        DeviceSpecific = 15
    }
}
