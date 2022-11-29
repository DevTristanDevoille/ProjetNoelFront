using ProjetNoelWeb.WebApplication.Commons;
using ProjetNoelWeb.WebApplication.Models.DTOs.Down;
using ProjetNoelWeb.WebApplication.Models.DTOs.Up;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

namespace ProjetNoelWeb.WebApplication.Services
{
    public class UserService : IUserService
    {

        #region privates
        private readonly IHttpService _httpService;
        #endregion

        #region CTOR
        public UserService(IHttpService httpService)
        {
            _httpService = httpService;

        }
        #endregion


        #region Login()
        public async Task<UserTokenDTODown> Login(UserConnexionDTOUp user)
        {
            // Get route + endpoint
            var url = $"{Constants.BaseUrlApi}Connexion";
            // Call the SendHttpRequest() method from httpService Shared
            var resultConnexion = await _httpService.SendHttpRequest<UserTokenDTODown>(url, HttpMethod.Post,user);
            // Return the adminsistrator
            return resultConnexion;
        }
        #endregion

        #region Register()
        public async Task Register(UserDTOUp user, string token)
        {
            // Get route + endpoint
            var url = $"{Constants.BaseUrlApi}users";
            // Call the SendHttpRequest() from the httpService Shared
            var resultRegister = await _httpService.SendHttpRequest<object>(url, HttpMethod.Post, user);
        }
        #endregion
    }
}
