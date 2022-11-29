using ProjetNoelWeb.WebApplication.Models.DTOs.Down;
using ProjetNoelWeb.WebApplication.Models.DTOs.Up;

namespace ProjetNoelWeb.WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Call login method in API (POST)
        /// </summary>
        /// <param name="username">The username in the input</param>
        /// <param name="password">The password in the input</param>
        /// <returns>The administrator</returns>
        Task<UserTokenDTODown> Login(UserConnexionDTOUp user);

        /// <summary>
        /// Call Register method in API (POST)
        /// </summary>
        /// <param name="administrator">The administrator</param>
        /// <param name="token">THe token in the Cookies</param>
        /// <returns></returns>
        Task Register(UserDTOUp user, string token);
    }
}
