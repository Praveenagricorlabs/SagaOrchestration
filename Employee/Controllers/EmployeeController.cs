using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {       

        [HttpPost(Name = "employee")]
        public IActionResult employee()
        {
            return Ok();
        }
    }
}