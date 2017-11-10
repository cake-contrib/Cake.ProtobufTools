using NUnit.Framework;
using System.Reflection;

namespace Cake.ProtobufTools.Tests
{
    public class ArgumentsBuilderExtensionTest
    {
        public static PropertyInfo StringProperty => GetProperty(nameof(TestSettings.String));
        public static PropertyInfo NullableBoolProperty => GetProperty(nameof(TestSettings.NullableBool));
        public static PropertyInfo NamedStringProperty => GetProperty(nameof(TestSettings.NamedString));
        public static PropertyInfo NamedBoolProperty => GetProperty(nameof(TestSettings.NamedBool));
        public static PropertyInfo GetProperty(string name)
        {
            return typeof(TestSettings).GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
        }
        [TestFixture]
        public class GetArgumentFromNullableBoolProperty
        {
            [Test]
            public void WhenTrueAndNoParameter_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, true, parameter: null);

                Assert.That(actual, Is.EqualTo("--nullable_bool"));
            }
            [Test]
            public void WhenFalseNoParameter_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, false, parameter: null);

                Assert.That(actual, Is.Null);
            }
            [Test]
            public void WhenNullNoParameter_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, null, parameter: null);

                Assert.That(actual, Is.Null);
            }
            [Test]
            public void WhenTrueAndParameter_UsesParameterName()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, true, 
                    parameter: new ParameterAttribute("-custom_name"));

                Assert.That(actual, Is.EqualTo("-custom_name"));
            }
        }
        [TestFixture]
        public class GetArgumentFromStringProperty
        {
            [Test]
            public void WhenGivenStringPropertyAndNoParameter_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, "tubo", parameter: null);

                Assert.That(actual, Is.EqualTo("--string=\"tubo\""));
            }
            [Test]
            public void WhenGivenStringPropertyAndGivenParameter_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, "tubo",
                    parameter: new ParameterAttribute("-custom_name"));

                Assert.That(actual, Is.EqualTo("-custom_name=\"tubo\""));
            }
            [Test]
            public void WhenGivenNullAndNoParameter_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, null, parameter: null);

                Assert.That(actual, Is.Null);
            }
        }

        [TestFixture]
        public class GetPropertyName
        {
            [TestCase("Name", ExpectedResult = "name")]
            [TestCase("NameExtended", ExpectedResult = "name_extended")]
            public string WhenInput_ReturnsCorrectlyFormatted(string name)
            {
                return ArgumentsBuilderExtension.GetPropertyName(name);
            }
        }
    }

    public class TestSettings: AutoToolSettings
    {
        public string String { get; set; }
        public bool? NullableBool { get; set; }
        [Parameter("--custome_string")]
        public string NamedString { get; set; }
        [Parameter("--custome_bool")]
        public bool? NamedBool { get; set; }

    }
}
