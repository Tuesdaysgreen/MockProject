using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mocking
{
    public class HttpClientWrapper : IDisposable
    {
        private HttpClient _client;

        public HttpClientWrapper(Func<HttpMessageHandler> handlerFactory)
        {
            if(handlerFactory == null)
            {
                this._client = new HttpClient();
            }
            else
            {
                this._client = new HttpClient(handlerFactory());
            }
        }

        public void Dispose()
        {
            if(this._client != null)
            {
                this._client.Dispose();
                this._client = null;
            }
        }

        public async Task<string> ReadContentAsStryingAsync(string url)
        {
            var result = await this._client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }
    }
}
