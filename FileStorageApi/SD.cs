using Microsoft.AspNetCore.Authorization;

namespace FileStorageApi
{
    public static class SD
    {
        //public const string Facebook = "facebook";
        //public const string Google = "google";

        // Roles
        public const string AdminRole = "Admin";
        public const string ManagerRole = "Manager";
        //public const string PlayerRole = "Player";
        public const string UserRole = "User";

        //Defining The Admin User For This Application
        public const string AdminUserFirstName = "Novel";
        public const string AdminUserLastName = "Khan";
        public const string AdminUserName = "novel4004@gmail.com";  //Email address as Username
        public const string AdminPassword = "123456";
        public const string SuperAdminChangeNotAllowed = "Super Admin change is not allowed!";
        public const int MaximumLoginAttempts = 3;

        //public static bool VIPPolicy(AuthorizationHandlerContext context)
        //{
        //    if (context.User.IsInRole(PlayerRole) &&
        //        context.User.HasClaim(c => c.Type == ClaimTypes.Email && c.Value.Contains("vip")))
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
