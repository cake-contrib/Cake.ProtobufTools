using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.ProtobufTools.Tests.Protoc
{
    public class ProtocFixture : ToolFixture<ProtocSettings>, ICakeContext
    {
        public FilePath[] ProtoFiles { get; set; }
        public string[] Services { get; set; } = new string[0];
        IFileSystem ICakeContext.FileSystem => FileSystem;
        ICakeEnvironment ICakeContext.Environment => Environment;
        public ICakeLog Log => Log;
        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();
        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;
        public IRegistry Registry => Registry;
        public ICakeDataResolver Data => throw new NotImplementedException();
        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();
        public ProtocFixture() : base("protoc")
        {
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.Protoc(Settings, ProtoFiles);
        }
    }
}
