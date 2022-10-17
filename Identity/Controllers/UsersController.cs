using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {      

        [HttpPost(Name = "Users")]
        public int  Users([FromBody] string name  )
        {
            if (name == "ravan") {
                throw new Exception("not allowed");
            }             
            return 1;
        }

        [HttpDelete(Name = "Users")]
        public IActionResult RemoveUsers(int id)
        {
            return Ok();
        }
    }
}