using Microsoft.AspNetCore.Mvc;

namespace License.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseController : ControllerBase
    {
        
        [HttpPost(Name = "License")]
        public int License(string name)
        {
            if (name == "liquor")
            {
                throw new Exception("not allowed");
            }
            return 1;             
        }

        [HttpDelete(Name = "License")]
        public IActionResult RemoveLicense(int id)
        {
            return Ok();
        }
    }
}