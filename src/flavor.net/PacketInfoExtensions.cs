using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor
{
    public static class PacketInfoExtensions
    {
        // These are implemented as generic methods, 
        // since we want to avoid boxing for PacketType.
        public static bool IsAudio<T>(this T info) where T : IPacketInfo
            => info.Content == PacketContent.Audio;

        public static bool IsVideo<T>(this T info) where T : IPacketInfo
            => info.Content == PacketContent.Video;

        public static bool IsMetadata<T>(this T info) where T : IPacketInfo
            => info.Content == PacketContent.Metadata;
    }
}
