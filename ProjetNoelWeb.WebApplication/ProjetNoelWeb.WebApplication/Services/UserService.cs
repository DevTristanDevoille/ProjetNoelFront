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
            var url = $"{Constants.BaseUrlApi}User/Connexion";
            // Call the SendHttpRequest() method from httpService Shared
            var resultConnexion = await _httpService.SendHttpRequest<UserTokenDTODown>(url, HttpMethod.Post,user);
            // Return the adminsistrator
            return resultConnexion;
        }
        #endregion

        #region Register()
        public async Task<UserTokenDTODown> Register(UserDTOUp user)
        {
            // Get route + endpoint
            var url = $"{Constants.BaseUrlApi}User";
            // Call the SendHttpRequest() from the httpService Shared
            UserTokenDTODown resultRegister = await _httpService.SendHttpRequest<UserTokenDTODown>(url, HttpMethod.Post,user);
            return resultRegister;
        }
        #endregion
    }
}
