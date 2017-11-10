using Cake.Core.IO;
using NUnit.Framework;

namespace Cake.ProtobufTools.Tests.Create.Apps
{
    [TestFixture]
    public class MobileCenter
    {
        [Test]
        public void WhenCSharpAndOFileAreSet_CommandLineIsCorrect()
        {
            var fixture = new ProtocFixture
            {
                Settings = new ProtocSettings { OSTarget = OSTarget.Windows64, CSharpOut = "some_folder", OFile = true },
                ProtoFiles = new FilePath[] {"definitions.proto" },
            };

            var actual = fixture.Run();
            Assert.That(actual.Args, Is.EqualTo("-oFILE --csharp_out=\"some_folder\" definitions.proto"));
        }
    }
}
