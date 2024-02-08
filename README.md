# Cake.ProtobufTools

A Cake AddIn that extends Cake with [Google.Protofbuf.Tools](https://github.com/google/protobuf/) command tools, namely protoc.

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)
[![NuGet](https://img.shields.io/nuget/v/Cake.ProtobufTools.svg)](https://www.nuget.org/packages/Cake.ProtobufTools)

|Branch|Status|
|------|------|
|Master|[![Build status](https://ci.appveyor.com/api/projects/status/github/cake-contrib/Cake.ProtobufTools?branch=master&svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-protobuftools)|
|Develop|[![Build status](https://ci.appveyor.com/api/projects/status/github/cake-contrib/Cake.ProtobufTools?branch=develop&svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-protobuftools)|

## Important

1.5.0
* References Cake 4.0.0
* Drops support for .NET Framework
* Supports .net 6+

## Including addin
Including addin in cake script is easy.
```c#
#addin "Cake.ProtobufTools"
```
Google.Protobuf.Tools package isn't included, it has to be added manually to your cake script.

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
	});
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

## Discussion

If you have questions, search for an existing one, or create a new discussion on the Cake GitHub repository, using the `extension-q-a` category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions/categories/extension-q-a)

## Credits

Brought to you by [Miha Markic](https://github.com/MihaMarkic) and contributors. 

![Mastodon Follow](https://img.shields.io/mastodon/follow/001030236)