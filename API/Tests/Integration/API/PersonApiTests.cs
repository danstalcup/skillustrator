using System;
using Xunit;

namespace Skillustrator.Tests.Integration.Api
{
    public class ApplicantControllerApiShould
    {
        private const string BASE_API_URL = "/api/person";
        private readonly TestWebServer _testWebServer;

        public ApplicantControllerApiShould()
        {
            _testWebServer = new TestWebServer();
        }

        /// Just here to ensure a connection to the TestHost is not an issue when a test breaks
        [Fact]
        public async void ReturnData()
        {
            var request = $"{BASE_API_URL}/{TestConstants.PERSON1_ID}";

            var response = await _testWebServer.GetUrlResponse(request);

            Console.WriteLine("RESPONSE:" + response + "REQUEST:" + request);
            Assert.Contains(TestConstants.PERSON1_LASTNAME, response);
        }

    }
}
