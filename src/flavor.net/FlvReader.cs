using Be.IO;
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

        }

        public FlvHeader ReadHeader()
        {

        }

        public FlvPacket ReadPacket()
        {

        }
    }
}
