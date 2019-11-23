using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using Serialization;

namespace AwesomeClient
{
    public class AwesomeClient
    {
        private readonly string uri;
        private ISerializationProvider serializationProvider;

        public AwesomeClient(string uri)
        {
            this.uri = uri;
            serializationProvider = SuperSerializer.GetSerializer(SerializationType.Json);
        }

        public async Task<bool> PingAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);

                var result = await client.GetAsync(GetUri("Ping")).ConfigureAwait(false);
                return result.StatusCode == HttpStatusCode.OK;
            }
        }

        public async Task<Input> GetInputDataAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);

                var result = await client.GetAsync(GetUri("InputDataAsync")).ConfigureAwait(false);
                var stringResult = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                return serializationProvider.Deserialize<Input>(stringResult);
            }
        }

        public async Task<bool> WriteAnswerAsync(string content, SerializationType serializationType)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                var httpContent = new StringContent(content);
                var result = await client.PostAsync(GetUri("WriteAnswer"), httpContent).ConfigureAwait(false);
                return result.StatusCode == HttpStatusCode.OK;
            }
        }

        private string GetContentType(SerializationType serializationType)
        {
            switch (serializationType)
            {
                case SerializationType.Json:
                    return "application/json";
                case SerializationType.Xml:
                    return "application/xml";
                default:
                    throw new ArgumentException("Неизвестный тип сериализации");
            }
        }


        private string GetUri(string method)
        {
            return $"{uri}/{method}";
        }
    }
}