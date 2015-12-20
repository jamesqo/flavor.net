using Be.IO;
using Flavor.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public class FlvFile : IBinarySerializable
    {
        public FlvFile(FlvHeader header, IEnumerable<FlvPacket> packets)
        {
            this.Header = header;
            this.Packets = packets.AsList();
        }

        public FlvHeader Header { get; }
        public List<FlvPacket> Packets { get; }

        public int Size
        {
            get
            {
                int header = FlvHeader.Size;
                int packets = Packets.Sum(p => p.Size);
                int sizes = 4 * Packets.Count + 4;
                return header + packets + sizes;
            }
        }

        public void CopyTo(Stream stream)
        {
            Header.CopyTo(stream);
            var writer = new BeBinaryWriter(stream);
            writer.Write(0); // Previous packet size for the first packet is always 0
            var packets = Packets; // Cache the result of the getter
            for (int i = 0; i < packets.Count; i++)
            {
                var packet = packets[i];
                packet.CopyTo(stream);
                writer.Write(packet.Size);
            }
        }
    }
}
