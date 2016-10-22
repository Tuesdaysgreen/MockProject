using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Mocking;
using Moq;
using System.Net.Http;
using System.Net;

namespace MockingTests
{
    [TestClass]
    public class HttpClientWrapperTests
    {
        [TestMethod]
        public async Task ReadContentAsStringAsync()
        {
            var url = "http://foo.com";
            var handler = new MockHttpMessageHandler();
            handler.AddExpectation(url, new MockHttpResponse()
            {
                Content = "foo",
                StatusCode = HttpStatusCode.OK
            });

            using (HttpClientWrapper client = new HttpClientWrapper(() => handler))
            {
                var content = await client.ReadContentAsStryingAsync(url);
                Assert.AreEqual("foo", content);
            }
            
        }
    }
}
