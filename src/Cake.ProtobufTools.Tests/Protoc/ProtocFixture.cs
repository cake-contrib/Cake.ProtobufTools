using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;
using System;

namespace Cake.ProtobufTools.Tests.Protoc
{
    public class ProtocFixture : ToolFixture<ProtocSettings>, ICakeContext
    {
        public FilePath[] ProtoFiles { get; set; }
        IFileSystem fileSystem;
        ICakeEnvironment environment;
        IFileSystem ICakeContext.FileSystem => fileSystem;
        ICakeEnvironment ICakeContext.Environment => environment;
        public ICakeLog Log => Log;
        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();
        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;
        public IRegistry Registry => Registry;
        public ProtocFixture() : base("protoc")
        {
            Tools = Substitute.For<IToolLocator>();
            fileSystem = Substitute.For<IFileSystem>();
            environment = Substitute.For<ICakeEnvironment>();
            var toolPath = new FilePath("mobile-center");
            var file = Substitute.For<IFile>();
            file.Exists.Returns(true);
            fileSystem.GetFile(toolPath).Returns(file);
            environment.WorkingDirectory.Returns("C:/Temp");
            Tools.Resolve("protoc").Returns(toolPath);
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.Protoc(Settings, ProtoFiles);
        }
    }
}
