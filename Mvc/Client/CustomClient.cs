using System.Net.Http.Headers;
namespace Mvc.Client
{
    public class CustomClient
    {
        public HttpClient _client;
        private IHttpContextAccessor _context;
        public CustomClient(HttpClient client,IHttpContextAccessor context)
        {
            _client = client;
            _context = context;
            client.BaseAddress = new Uri("https://localhost:7206/");
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _context.HttpContext.Session.GetString("token"));
        }
    }
}
