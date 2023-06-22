using Project1.Dtos;
using System.Text.Json;

namespace Project1.Helpers
{

    public class HttpService
    {
        private readonly HttpContext _context;

        public HttpService(IHttpContextAccessor context)
        {
            _context = context.HttpContext;
        }

    }
}
