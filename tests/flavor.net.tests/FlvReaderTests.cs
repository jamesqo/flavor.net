using Flavor.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flavor.Tests
{
    public class FlvReaderTests
    {
        [Fact]
        public void ReadHelloFlv()
        {
            var stream = FlvCache.AdeleHello.AsStream();
            var reader = new FlvReader(stream);
            var file = reader.ReadFlv();
        }
    }
}
