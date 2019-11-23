using System;
using System.Collections.Generic;
using System.IO;

namespace Serialization
{
    public static class SuperSerializer
    {
        private static readonly Dictionary<SerializationType, ISerializationProvider> serializers = new Dictionary<SerializationType, ISerializationProvider>();

        public static ISerializationProvider GetSerializer(SerializationType serializationType)
        {
            if (serializers.ContainsKey(serializationType))
            {
                return serializers[serializationType];
            }

            var serializationProvider = ResolveProvider(serializationType);
            serializers[serializationType] = serializationProvider;
            return serializationProvider;
        }

        private static ISerializationProvider ResolveProvider(SerializationType serializationType)
        {
            switch (serializationType)
            {
                case SerializationType.Xml:
                    return new XmlSerializationProvider();
                case SerializationType.Json:
                    return new JsonSerializationProvider();
                default: throw new Exception("Неопознанный тип сериализайзера.");
            }
        }
    }
}