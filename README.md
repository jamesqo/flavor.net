# Flavor

<img src="http://i.imgur.com/DYgCmNm.png" width="30%"/>

[![](https://img.shields.io/travis/jamesqo/flavor.net.svg?style=flat-square)](https://travis-ci.org/jamesqo/flavor.net) [![](https://img.shields.io/appveyor/ci/jamesqo/flavor-net.svg?style=flat-square)](https://ci.appveyor.com/project/jamesqo/flavor-net) [![](https://img.shields.io/badge/license-BSD-blue.svg?style=flat-square)](license.bsd)

Flavor is an intuitive library to parse and manipulate FLV files from .NET.

# Installation

Run this from your NuGet Console:

```powershell
Install-Package flavor.net
```

# Supported Platforms

Just about every platform is supported, including:

- .NET Framework 4.5
- Windows 10, 8.1, and 8.0 apps
- Mono (Mac/Linux) and Xamarin
- .NET Core
- ASP.NET 5 and DNX
- Windows Phone 8.1 and 8.0
- Silverlight 5

# Getting Started

Here's a small sample to help you get started with Flavor:

```csharp
using Flavor;

FlvFile file;
using (var input = File.OpenRead("foo.flv"))
    file = Flv.Parse(input);

foreach (var packet in file.Packets)
{
    Console.WriteLine($"{packet.Type} packet encountered!");
    Console.WriteLine($"It is {packet.Size} bytes long...");
    Console.WriteLine("Here's the raw binary data:");
    Console.WriteLine(string.Join(" ", packet.Data.ToByteArray()));
}

using (var output = File.OpenWrite("bar.flv"))
    file.CopyTo(output);
```

# Building the Repo

Flavor uses the excellent [Cake](http://cakebuild.net/) automation system for builds. To get a fresh copy of Flavor, clone the repo and run

```powershell
./build.ps1 # Windows
./build.sh # Mac/Linux
```

The assemblies should be in `artifacts/bin/flavor.net` after the build finishes.

# License

Flavor is licensed under the [BSD simplified license](license.bsd).
