namespace Serialization
{
    public interface ISerializationProvider
    {
        string Serialize<T>(T objectForSerialization);
        T Deserialize<T>(string stringForDeserialization);
    }
}