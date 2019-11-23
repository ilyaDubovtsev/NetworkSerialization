using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.AwesomeClientTest
{
    public class AwesomeClientTest
    {
        private AwesomeClient.AwesomeClient awesomeClient;
        private const string url = "http://google.com";

        [SetUp]
        public void Setup()
        {
            awesomeClient = new AwesomeClient.AwesomeClient(url);
        }

        [Test]
        public async Task TestPing()
        {
            var ping = await awesomeClient.PingAsync().ConfigureAwait(false);
            ping.Should().BeTrue();
        }
    }
}