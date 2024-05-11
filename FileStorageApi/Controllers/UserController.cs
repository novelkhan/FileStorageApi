using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorageApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("get-users")]
        public IActionResult Users()
        {
            return Ok(new JsonResult(new { message = "Only authorized users can view this action method" }));
        }
    }
}
