using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MockingTests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private Dictionary<string, MockHttpResponse> _expectations = new Dictionary<string, MockHttpResponse>();

        public void AddExpectation(string url, MockHttpResponse expectation)
        {
            this._expectations.Add(new Uri(url).ToString(), expectation);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = this._expectations[request.RequestUri.ToString()];
            var responseMessage = new HttpResponseMessage(response.StatusCode);
            responseMessage.Content = new StringContent(response.Content);
            return Task.FromResult(responseMessage);
        }
    }
}
