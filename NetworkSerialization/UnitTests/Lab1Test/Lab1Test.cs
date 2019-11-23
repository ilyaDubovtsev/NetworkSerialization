using FluentAssertions;
using Lab1;
using NUnit.Framework;

namespace UnitTests.Lab1Test
{
    public class Lab1Test
    {
        private LabSerialization labSerialization;

        [SetUp]
        public void Setup()
        {
            labSerialization = new LabSerialization();
        }

        [Test]
        public void XmlTest()
        {
            var input = "<Input>" +
                        "<K>10</K>" +
                        "<Sums>" +
                        "<decimal>1.01</decimal>" +
                        "<decimal>2.02</decimal>" +
                        "</Sums>" +
                        "<Muls>" +
                        "<int>1</int>" +
                        "<int>4</int>" +
                        "</Muls>" +
                        "</Input>";

            var actual = LabSerialization.Process("Xml", input);

            var expected = "<Output>" +
                        "<SumResult>30.30</SumResult>" +
                        "<MulResult>4</MulResult>" +
                        "<SortedInputs>" +
                        "<decimal>1</decimal>" +
                        "<decimal>1.01</decimal>" +
                        "<decimal>2.02</decimal>" +
                        "<decimal>4</decimal>" +
                        "</SortedInputs>" +
                        "</Output>";

            actual.Should().Be(expected);
        }

        [Test]
        public void JsonTest()
        {
            var input = "{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\":[1,4]}";

            var actual = LabSerialization.Process("Json", input);

            var expected = "{\"SumResult\":30.30,\"MulResult\":4,\"SortedInputs\":[1.0,1.01,2.02,4.0]}";

            actual.Should().Be(expected);
        }
    }
}