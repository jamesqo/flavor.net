using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor
{
    public class FlvWriter : IDisposable
    {
        public FlvWriter(Stream output)
        {
            this.BaseStream = output;
        }

        public Stream BaseStream { get; }

        public void Dispose() =>
            Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                BaseStream.Dispose();
        }

        public void Write<T>(T obj)
            where T : IBinarySerializable
        {
            obj.CopyTo(BaseStream);
        }
    }
}
