using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using System;
using System.Linq;

namespace Cake.ProtobufTools
{
    /// <summary>
    /// Contains functionality for working with ProtobufTools.
    /// </summary>
    /// <remarks>Requires Google.Protobuf.Tools NuGet package in your script as a tool.</remarks>
    /// <example>
    /// #tool nuget:?package=Google.Protobuf.Tools
    /// </example>
    partial class ProtobufToolsAliases
    {
        /// <summary>
        /// Invokes protoc executable.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="files">Input files.</param>
        [CakeMethodAlias]
        public static void Protoc(this ICakeContext context, ProtocSettings settings, params FilePath[] files)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (files == null || files.Length == 0)
            {
                throw new ArgumentNullException("files");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            var runner = new ProtobufTools(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings, files.Select(f => $"\"{f.FullPath}\"").ToArray());
        }
    }
}
