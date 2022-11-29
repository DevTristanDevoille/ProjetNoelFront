using ProjetNoelWeb.WebApplication.Commons;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

namespace ProjetNoelWeb.WebApplication.Services
{
    public class SquadService : ISquadService
    {
        #region privates
        private readonly IHttpService _httpService;
        #endregion

        #region CTOR
        public SquadService(IHttpService httpService)
        {
            _httpService = httpService;

        }
        #endregion

        #region GetAllSquad
        public async Task<IEnumerable<Squad>> GetAllSquad(string token)
        {
            var url = $"{Constants.BaseUrlApi}Squad/GetAll";
            // Call the SendHttpRequest() method from httpService Shared
            var resultConnexion = await _httpService.SendHttpRequest<List<Squad>>(url, HttpMethod.Get,bearer:token);
            return resultConnexion;
        }
        #endregion
    }
}
