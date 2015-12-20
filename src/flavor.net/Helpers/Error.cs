using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flavor.Helpers
{
    internal static class Error
    {
        public static InvalidDataException InvalidData(string message = null) =>
            new InvalidDataException(message);

        public static InvalidOperationException InvalidOperation(string message = null) =>
            new InvalidOperationException(message);

        public static ArgumentOutOfRangeException OutOfRange() =>
            new ArgumentOutOfRangeException();
        public static ArgumentOutOfRangeException OutOfRange(string name, string message = null) =>
            new ArgumentOutOfRangeException(name, message);

        public static NotImplementedException NotImplemented(string message = null) =>
            new NotImplementedException(message);
    }
}
