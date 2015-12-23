using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary;

namespace Flavor.Tests
{
    public static class FlvCache
    {
        // Yes, I know this is mutable. No, I don't care.
        public static readonly byte[] AdeleHello = GetVideoFromId("YQHsXMglC9A");

        private static byte[] GetVideoFromId(string id)
        {
            string url = $"https://youtube.com/watch?v={id}";
            var videos = YouTube.Default.GetAllVideos(url);
            var video = videos.First(v => v.Format == VideoFormat.Flash);
            return video.GetBytes();
        }
    }
}
