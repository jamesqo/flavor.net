# Flavor

<img src="http://i.imgur.com/DYgCmNm.png" width="30%"/>

[![](https://img.shields.io/travis/jamesqo/flavor.net.svg?style=flat-square)](https://travis-ci.org/jamesqo/flavor.net) [![](https://img.shields.io/appveyor/ci/jamesqo/flavor-net.svg?style=flat-square)](https://ci.appveyor.com/project/jamesqo/flavor-net) [![](https://img.shields.io/badge/license-BSD-blue.svg?style=flat-square)](license.bsd)

Flavor is an intuitive library to parse and manipulate FLV files from .NET.

# Installation

Run this from the Package Manager Console:

```powershell
Install-Package flavor.net
```

# Getting Started

Here's a small sample to help you get started with Flavor:

```csharp
using Flavor;

FlvFile file;
using (var input = File.OpenRead("foo.flv"))
    file = Flv.Parse(input);

foreach (var packet in file.Packets)
{
    Console.WriteLine($"{packet.Type.Content} packet encountered!");
    Console.WriteLine($"It is {packet.Size} bytes long...");
    Console.WriteLine("Here's the raw binary data:");
    Console.WriteLine(string.Join(" ", packet.Data.ToByteArray()));
}

using (var output = File.OpenWrite("bar.flv"))
    file.CopyTo(output);
```

# Building the Repo

# License

Flavor is licensed under the [BSD simplified license](license.bsd).
