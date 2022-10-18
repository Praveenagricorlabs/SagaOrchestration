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
            // entry in identity db
            var identityClient = _httpClientFactory?.CreateClient("identity");
            var identityData = new StringContent( JsonSerializer.Serialize(name), Encoding.UTF8, Application.Json);
            var identityResponse = await identityClient?.PostAsync("https://localhost:7249/users", identitydata);

            var identityId=await identityResponse.Content.ReadAsStringAsync();

            try {

                // entry in license db
                var licenseClient = _httpClientFactory?.CreateClient("license");
                var licensedata = new StringContent(JsonSerializer.Serialize("liq"), Encoding.UTF8, Application.Json);
                var licenseResponse = await licenseClient?.PostAsync("https://localhost:7194/license", licensedata);

            }
            catch (Exception ex) {

                // compensating transaction if license entry fails
                var d = await identityClient?.DeleteAsync("https://localhost:7249/users/" + identityId);

            }


            return Ok();
        }
    }
}