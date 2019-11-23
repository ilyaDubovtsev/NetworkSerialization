using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization
{
    public class XmlSerializationProvider : ISerializationProvider
    {
        public string Serialize<T>(T objectForSerialization)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };
            var serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add("", "");

            using (var streamWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(streamWriter, new XmlWriterSettings() { OmitXmlDeclaration = true }))
                {
                    xmlSerializer.Serialize(xmlWriter, objectForSerialization, serializerNamespaces);
                    return streamWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(string stringForDeserialization)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(stringForDeserialization))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }
    }
}
