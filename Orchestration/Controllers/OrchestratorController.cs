using Microsoft.AspNetCore.Mvc;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace Orchestration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrchestratorController : ControllerBase
    {
        IHttpClientFactory? _httpClientFactory;
        public OrchestratorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost(Name = "AddEmployee")]
        public async Task<IActionResult> AddEmployee(string name)
        {
            var identityClient = _httpClientFactory?.CreateClient("identity");
            var data = new StringContent( JsonSerializer.Serialize(name), Encoding.UTF8, Application.Json);
            var result = await identityClient?.PostAsync("https://localhost:7249/users", data);
            return Ok();
        }
    }
}