using Newtonsoft.Json;

namespace Serialization
{
    public class JsonSerializationProvider : ISerializationProvider
    {
        public string Serialize<T>(T objectForSerialization)
        {
            return JsonConvert.SerializeObject(objectForSerialization);
        }

        public T Deserialize<T>(string stringForDeserialization)
        {
            return JsonConvert.DeserializeObject<T>(stringForDeserialization);
        }
    }
}