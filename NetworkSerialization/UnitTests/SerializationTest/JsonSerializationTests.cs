using FluentAssertions;
using NUnit.Framework;
using Serialization;

namespace UnitTests.SerializationTest
{
    public class JsonSerializationTests
    {
        private JsonSerializationProvider jsonSerializationProvider;
        private string jsonString;

        [SetUp]
        public void Setup()
        {
            jsonSerializationProvider = new JsonSerializationProvider();
            jsonString = "{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\":[1,4]}";
        }

        [Test]
        public void TestSerializeSimpleObject()
        {
            var input = GetTestSerializableObject();

            var actual = jsonSerializationProvider.Serialize(input);

            actual.Should().Be(jsonString);
        }

        [Test]
        public void TestDeserializeSimpleObject()
        {
            var actual = jsonSerializationProvider.Deserialize<SerializableObject>(jsonString);

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
