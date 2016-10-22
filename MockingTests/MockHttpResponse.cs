using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MockingTests
{
    public class MockHttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
}
