using FluentAssertions;
using NUnit.Framework;
using Serialization;

namespace UnitTests.Serialization
{
    public class XmlSerializationTests
    {
        private readonly string xmlString =
            "<Input><K>10</K><Sums><decimal>1.01</decimal><decimal>2.02</decimal></Sums><Muls><int>1</int><int>4</int></Muls></Input>";
        private XmlSerializationProvider xmlSerializationProvider;

        [SetUp]
        public void Setup()
        {
            xmlSerializationProvider = new XmlSerializationProvider();
        }

        [Test]
        public void TestSerializeSimpleObject()
        {
            var input = GetTestSerializableObject();

            var actual = xmlSerializationProvider.Serialize(input);

            actual.Should().Be(xmlString);
        }

        [Test]
        public void TestDeserializeSimpleObject()
        {
            var actual = xmlSerializationProvider.Deserialize<SerializableObject>(xmlString);

            var expected = GetTestSerializableObject();

            actual.Should().BeEquivalentTo(expected);
        }

        private static SerializableObject GetTestSerializableObject()
        {
            return new SerializableObject
            {
                K = 10,
                Muls = new []{1, 4},
                Sums = new[]{1.01M, 2.02M}
            };
        }

    }
}