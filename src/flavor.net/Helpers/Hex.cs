using System;
using System.Collections.Generic;
using System.Linq;

namespace Flavor.Helpers
{
    internal static class Hex
    {
        public static string ToString(byte b) =>
            $"0x{b.ToString("X")}";

        public static string ToString(short s) =>
            $"0x{s.ToString("X")}";

        public static string ToString(int i) =>
            $"0x{i.ToString("X")}";

        public static string ToString(long l) =>
            $"0x{l.ToString("X")}";
    }
}
