using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;

namespace Cake.ProtobufTools
{
    /// <summary>
    /// 
    /// </summary>
    public class ProtobufTools : Tool<ProtocSettings>
    {
        readonly ICakeEnvironment environment;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        public ProtobufTools(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Runs protoc using given <paramref name=" settings"/> and <paramref name="additional"/>.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="additional"></param>
        public void Run(ProtocSettings settings, string[] additional)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            if (additional == null)
            {
                throw new ArgumentNullException(nameof(additional));
            }
            Run(settings, GetArguments(settings, additional));
        }

        private ProcessArgumentBuilder GetArguments(ProtocSettings settings, string[] files)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(settings, files);
            return builder;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "ProtobufTools";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "protoc.exe", "protoc" };
        }
        /// <summary>
        /// Finds the proper protoc executable path.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>A single path to protoc executable.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(ProtocSettings settings)
        {
            var osTarget = GetTarget(settings.OSTarget, environment.Platform);
            var exe = IsWindows(osTarget) ? "protoc.exe" : "protoc";
            string path = System.IO.Path.Combine("..", "..", "..", "..", "google.protobuf.tools", "Google.Protobuf.Tools", "tools", DirectoryFromTarget(osTarget), exe);
            return new FilePath[] { new FilePath(path) };
        }
        /// <summary>
        /// Checks if target is Windows.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>True when target is Windows, false otherwise.</returns>
        public static bool IsWindows(OSTarget target) => target == OSTarget.Windows64 || target == OSTarget.Windows86;
        /// <summary>
        /// Get's protoc directory based on <paramref name="target"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>Returns last directory part for given OS.</returns>
        public  static string DirectoryFromTarget(OSTarget target)
        {
            switch (target)
            {
                case OSTarget.Google:
                    return "google";
                case OSTarget.Linux64:
                    return "linux_x64";
                case OSTarget.Linux86:
                    return "linux_x86";
                case OSTarget.MacOSX64:
                    return "macosx_x64";
                case OSTarget.MacOSX86:
                    return "macosx_x86";
                case OSTarget.Windows64:
                    return "windows_x64";
                case OSTarget.Windows86:
                    return "windows_x86";
                default:
                    throw new Exception($"Unknown OSTarget {target}");
            }
        }
        /// <summary>
        /// Automatically determines the <see cref="OSTarget"/>.
        /// </summary>
        /// <param name="source">The target specified by user, can be null.</param>
        /// <param name="platform">The Cake platform.</param>
        /// <returns>Returns a <see cref="OSTarget"/> based on input parameters.</returns>
        /// <remarks>Throws an exception if it can't determine the OS.</remarks>
        public static OSTarget GetTarget(OSTarget? source, ICakePlatform platform)
        {
            if (source.HasValue)
            {
                return source.Value;
            }
            else
            {
                switch (platform.Family)
                {
                    case PlatformFamily.Linux:
                        return platform.Is64Bit ? OSTarget.Linux64 : OSTarget.Linux86;
                    case PlatformFamily.OSX:
                        return platform.Is64Bit ? OSTarget.MacOSX64 : OSTarget.MacOSX86;
                    case PlatformFamily.Windows:
                        return platform.Is64Bit ? OSTarget.Windows64 : OSTarget.Windows86;
                    default:
                        throw new Exception($"No OSTarget is given in settings, couldn't determine the platform: {platform.Family} {(platform.Is64Bit ? "x64" : "x86")}");
                }
            }
        }
    }
}
