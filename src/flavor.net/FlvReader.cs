using Be.IO;
using Flavor.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public class FlvReader : IDisposable
    {
        private readonly BeBinaryReader reader;

        public FlvReader(Stream input)
        {
            this.reader = new BeBinaryReader(input);
        }

        public Stream BaseStream => reader.BaseStream;

        public void Dispose() =>
            Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                reader.Dispose();
        }

        public FlvFile ReadFlv()
        {
            var header = ReadHeader();
            var s = BaseStream;
            var length = s.Length; // cache the length
            var packets = new List<FlvPacket>();

            if (s.Position + 4 <= length)
            {
                s.Seek(4, SeekOrigin.Current); // the first packet size is always 0
                while (s.Position + 4 <= length)
                {
                    packets.Add(ReadPacket());
                    s.Seek(4, SeekOrigin.Current); // skip the size of the previous packet
                }
            }
            s.Seek(0, SeekOrigin.End); // skip to the end of the stream

            return new FlvFile(header, packets);
        }

        public FlvHeader ReadHeader()
        {
            // Check if we're an FLV file
            int read = reader.ReadInt32();
            if (read != 0x464C5601) // "FLV" and a version number of 1
            {
                if (read == 0x66747970) // "ftyp"
                    throw Error.InvalidData("This is an MP4 file, not an FLV file!");
                throw Error.InvalidData("This is not an FLV file!");
            }

            var flags = (HeaderFlags)reader.ReadByte();
            BaseStream.Position = reader.ReadInt32();
            return new FlvHeader
            {
                Flags = flags
            };
        }

        public FlvPacket ReadPacket()
        {
            var type = (PacketType)reader.ReadByte();
            int dataSize = reader.ReadInt24();
            int timeStamp = reader.ReadInt24();
            timeStamp |= reader.ReadByte() << 24;
            BaseStream.Seek(3, SeekOrigin.Current); // skip the StreamID

            PacketData data;
            switch (type.Content)
            {
                case PacketContent.Audio:
                    var audioInfo = reader.ReadByte();
                    byte[] bytes = reader.ReadBytes(dataSize - 1);
                    data = new AudioData
                    {
                        AudioInfo = audioInfo,
                        RawData = bytes
                    };
                    break;
                case PacketContent.Metadata:
                    data = new ScriptData
                    {
                        RawData = reader.ReadBytes(dataSize)
                    };
                    break;
                case PacketContent.Video:
                    var videoInfo = reader.ReadByte();
                    byte[] buffer = reader.ReadBytes(dataSize - 1);
                    data = new VideoData
                    {
                        RawData = buffer,
                        VideoInfo = videoInfo
                    };
                    break;
                default:
                    throw Error.InvalidData($"{Hex.ToString(type)} is not a valid tag type!");
            }

            return new FlvPacket(data)
            {
                TimeStamp = timeStamp,
                Type = type
            };
        }
    }
}
