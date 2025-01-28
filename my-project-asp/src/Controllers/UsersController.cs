using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using my_dotnet_core_project.Interfaces;

namespace my_dotnet_core_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser([FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest(new { message = "Username cannot be empty." });
            }

            try
            {
                var result = _userService.GetUserByUsername(username);
                if (result != null)
                {
                    return Ok(new { message = "Hello, " + result });
                }
                else
                {
                    return NotFound(new { message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }
    }
}
