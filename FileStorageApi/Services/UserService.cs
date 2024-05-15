using FileStorageApi.Interfaces;
using FileStorageApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileStorageApi.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }







        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            // Asynchronously get the authentication status from the HttpContext
            return Task.FromResult(_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated);
        }










        public string? GetCurrentUserId()
        {
            // Get the user ID from the HttpContext
            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public Task<string?> GetCurrentUserIdAsync()
        {
            // Asynchronously get the user ID from the HttpContext
            return Task.FromResult(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }








        public User? GetCurrentUser()
        {
            // Get the user ID from the HttpContext synchronously
            string? userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return null;
            }

            // Retrieve the AppUser object from the database synchronously
            User? user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();

            return user;
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            //// Get the user ID from the HttpContext
            //// Get the user ID of the currently logged-in user
            //string? userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);


            // Get the user ID from the HttpContext
            // Asynchronously get the user ID of the currently logged-in user
            string? userId = await Task.Run(() => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));

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

    }
}
