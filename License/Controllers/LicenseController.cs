using Microsoft.AspNetCore.Mvc;

namespace License.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseController : ControllerBase
    {
        
        [HttpPost(Name = "License")]
        public int License([FromBody]  string name)
        {
            if (name == "drugs")
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