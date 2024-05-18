using FileStorageApi.Interfaces;
using FileStorageApi.Models;
using FileStorageApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileStorageApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UserController(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }



        [HttpGet("get-users")]
        public IActionResult Users()
        {
            return Ok(new JsonResult(new { message = "Only authorized users can view this action method" }));
        }

















        private User? GetCurrentUser()
        {
            // Get the user ID of the currently logged-in user synchronously
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            // Retrieve the AppUser object from the database synchronously
            User? user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();

            return user;
        }


        private async Task<User?> GetCurrentUserAsync()
        {
            //// Get the user ID of the currently logged-in user
            //string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            // Asynchronously get the user ID of the currently logged-in user
            string? userId = await Task.Run(() => User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (userId == null)
            {
                return null;
            }

            // Retrieve the AppUser object from the database
            User? user = await _userManager.FindByIdAsync(userId);

            // Now you have access to the custom properties like FirstName, LastName, etc.
            // ...


            return user;
        }





        private string? GetCurrentUserId()
        {
            // Get the user ID of the currently logged-in user
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId;
        }


        private async Task<string?> GetCurrentUserIdAsync()
        {
            //// Get the user ID of the currently logged-in user
            //string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            // Asynchronously get the user ID of the currently logged-in user
            string? userId = await Task.Run(() => User.FindFirstValue(ClaimTypes.NameIdentifier));

            return userId;
        }
    }
}