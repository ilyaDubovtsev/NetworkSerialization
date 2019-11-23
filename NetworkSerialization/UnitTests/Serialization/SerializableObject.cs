using System.Xml.Serialization;

namespace UnitTests.Serialization
{
    [XmlRoot("Input")]
    public class SerializableObject
    {
        [XmlElement("K")]
        public int K { get; set; }
        [XmlArray(ElementName = "Sums")]
        public decimal[] Sums { get; set; }
        [XmlArray(ElementName = "Muls")]
        public int[] Muls { get; set; }
    }
}