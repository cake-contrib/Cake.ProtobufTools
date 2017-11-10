# Cake.ProtobufTools

A Cake AddIn that extends Cake with [Google.Protofbuf.Tools](https://github.com/google/protobuf/) command tools, namely protoc.

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)
[![NuGet](https://img.shields.io/nuget/v/Cake.ProtobufTools.svg)](https://www.nuget.org/packages/Cake.ProtobufTools)

## Including addin
Including addin in cake script is easy.
```c#
#addin "Cake.ProtobufTools"
```
Google.Protobuf.Tools package isn't included, it has to added manually to your cake script.

```c#
#tool nuget:?package=Google.Protobuf.Tools
```

## Usage

To use the addin just add it to Cake call the aliases and configure any settings you want.

```csharp
#addin "Cake.ProtobufTools"
#tool nuget:?package=Google.Protobuf.Tools

...

Task("ProtobufGenerator")
	.Does(() => {
		var settings = new ProtocSettings
        {
                CSharpOut = Directory("."),
        };
        var file = File("./definitions.proto");
        Protoc(settings, file);
	)};
```
Since Google.ProtobufTools nuget package comes with different executable flavors (Linux, Windows, MacOS X - all having both x86 and x64 versions) the addin, unless explicitly defined, uses the most appropriate based on OS you are running the script. 

You can force it using _ProtocSettings.OSTarget_ property, i.e.:

```c#
var settings = new ProtocSettings
{
	OSTarget = OSTarget.Linux64,
	...
};
```



## Credits

Brought to you by [Miha Markic](https://github.com/MihaMarkic) ([@MihaMarkic](https://twitter.com/MihaMarkic/)) and contributors.