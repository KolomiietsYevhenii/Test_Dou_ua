using System.Net.Http;
using System.Threading.Tasks;

namespace TestDou.Ua
{
    class HttpRequestSender
    {
        public async Task<HttpResponseMessage> SendGet(string url)
        {
            var client = new HttpClient();

            return await client.GetAsync(url);
        }
    }
}
