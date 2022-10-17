using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Text;

namespace Saga.Orchestration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrchestratorController : ControllerBase
    {
        IHttpClientFactory? _httpClientFactory;
        public void Orchestrator(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost(Name = "AddEmployee")]
        public async Task<IActionResult> AddEmployee(string name)
        {
            var identityClient= _httpClientFactory?.CreateClient("identity");
            var result = await identityClient?.PostAsync("localhost:7249/", new StringContent("ravan", Encoding.UTF8, "application/json"));
            return Ok();
        }
    }
}