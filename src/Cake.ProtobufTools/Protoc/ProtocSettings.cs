namespace Cake.ProtobufTools
{
    /// <summary>
    /// Settings for protoc.
    /// </summary>
    public class ProtocSettings : AutoToolSettings
    {
        /// <summary>
        /// Specifies what protoc executable will run.
        /// </summary>
        public OSTarget? OSTarget { get; set; }
        /// <summary>
        /// Specify the directory in which to search for
        /// imports.May be specified multiple times;
        /// directories will be searched in order.If not
        /// given, the current working directory is used.
        /// </summary>
        public string ProtoPath { get; set; }
        /// <summary>
        /// Read a text-format message of the given type
        /// from standard input and write it in binary
        /// to standard output.The message type must
        /// be defined in PROTO_FILES or their imports.
        /// </summary>
        public string Encode { get; set; }
        /// <summary>
        /// Read a binary message of the given type from
        /// standard input and write it in text format
        /// to standard output.The message type must
        /// be defined in PROTO_FILES or their imports.
        /// </summary>
        public string Decode { get; set; }
        /// <summary>
        /// Read an arbitrary protocol message from
        /// standard input and write the raw tag/value
        /// pairs in text format to standard output.No
        /// PROTO_FILES should be given when using this
        /// flag.
        /// </summary>
        public bool? DecodeRaw { get; set; }
        /// <summary>
        /// Specifies a delimited list of FILES
        /// each containing a FileDescriptorSet(a
        /// protocol buffer defined in descriptor.proto).
        /// The FileDescriptor for each of the PROTO_FILES
        /// provided will be loaded from these
        /// FileDescriptorSets.If a FileDescriptor
        /// appears multiple times, the first occurrence
        /// will be used.
        /// </summary>
        public string DescriptorSetIn { get; set; }
        /// <summary>
        /// Writes a FileDescriptorSet (a protocol buffer, defined in descriptor.proto) containing all of
        /// the input files to FILE.
        /// </summary>
        [Parameter("-oFILE")]
        public bool? OFile { get; set; }
        /// <summary>
        /// Writes a FileDescriptorSet (a protocol buffer, defined in descriptor.proto) containing all of
        /// the input files to FILE.
        /// </summary>
        public string DescriptorSetOut { get; set; }
        /// <summary>
        /// When using --descriptor_set_out, also include
        /// all dependencies of the input files in the
        /// set, so that the set is self-contained.
        /// </summary>
        public bool? IncludeImports { get; set; }
        /// <summary>
        /// When using --descriptor_set_out, do not strip
        /// SourceCodeInfo from the FileDescriptorProto.
        /// This results in vastly larger descriptors that
        /// include information about the original
        /// location of each decl in the source file as
        /// well as surrounding comments.
        /// </summary>
        public bool? IncludeSourceInfo { get; set; }
        /// <summary>
        ///  Write a dependency output file in the format
        /// expected by make.This writes the transitive
        /// set of input file paths to FILE
        /// </summary>
        public string DependencyOut { get; set; }
        /// <summary>
        /// Set the format in which to print errors.
        /// FORMAT may be 'gcc' (the default) or 'msvs'
        /// (Microsoft Visual Studio format).
        /// </summary>
        public string ErrorFormat { get; set; }
        /// <summary>
        /// Print the free field numbers of the messages
        /// defined in the given proto files.Groups share
        /// the same field number space with the parent
        /// message. Extension ranges are counted as
        /// occupied fields numbers.
        /// </summary>
        public bool? PrintFreeFieldNumbers { get; set; }
        /// <summary>
        /// Specifies a plugin executable to use.
        /// Normally, protoc searches the PATH for
        /// plugins, but you may specify additional
        /// executables not in the path using this flag.
        /// Additionally, EXECUTABLE may be of the form
        /// NAME= PATH, in which case the given plugin name
        /// is mapped to the given executable even if
        /// the executable's own name differs.
        /// </summary>
        public string Plugin { get; set; }
        /// <summary>
        /// Generate C++ header and source.
        /// </summary>
        public string CppOut { get; set; }
        /// <summary>
        /// Generate C# source file.
        /// </summary>
        [Parameter("--csharp_out")]
        public string CSharpOut { get; set; }
        /// <summary>
        /// Generate Java source file.
        /// </summary>
        public string JavaOut { get; set; }
        /// <summary>
        /// Generate Java Nano source file.
        /// </summary>
        public string JavananoOut { get; set; }
        /// <summary>
        /// Generate JavaScript source file.
        /// </summary>
        public string JsOut { get; set; }
        /// <summary>
        /// Generate ObjectiveC header and source.
        /// </summary>
        public string ObjcOut { get; set; }
        /// <summary>
        /// Generate PHP source file.
        /// </summary>
        public string PhpOut { get; set; }
        /// <summary>
        /// Generate Python source file.
        /// </summary>
        public string PythonOut { get; set; }
        /// <summary>
        /// Generate Ruby source file.
        /// </summary>
        public string RubyOut { get; set; }
    }
}
