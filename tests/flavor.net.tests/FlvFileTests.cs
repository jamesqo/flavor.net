using Flavor.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flavor.Tests
{
    public class FlvFileTests
    {
        [Fact]
        public void SerializeAndDeserialize()
        {
            var source = FlvCache.AdeleHello;
            var file = Flv.Parse(source);
            var generated = file.ToByteArray();
            Assert.True(source.SequenceEqual(generated)); // TODO: I would use Assert.Equal() here, but it's pretty much useless since it doesn't show you the index of difference.
        }
    }
}
