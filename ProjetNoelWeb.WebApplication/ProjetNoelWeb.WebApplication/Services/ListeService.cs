using ProjetNoelWeb.WebApplication.Commons;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

namespace ProjetNoelWeb.WebApplication.Services
{
    public class ListeService : IListeService
    {
        #region privates
        private readonly IHttpService _httpService;
        #endregion

        #region CTOR
        public ListeService(IHttpService httpService)
        {
            _httpService = httpService;

        }
        #endregion
        public async Task<List<Liste>> GetAllListes(int idSquad,string token)
        {
            var url = $"{Constants.BaseUrlApi}Liste?idSquad={idSquad}";
            List<Liste> resultListe = await _httpService.SendHttpRequest<List<Liste>>(url, HttpMethod.Get,bearer:token);
            return resultListe;
        }

        public async Task<Liste> GetListe(int idListe,string token)
        {
            var url = $"{Constants.BaseUrlApi}Liste/GetById?idListe={idListe}";
            Liste resultListe = await _httpService.SendHttpRequest<Liste>(url, HttpMethod.Get, bearer: token);
            return resultListe;
        }

        public async Task<Liste> CreateListe(Liste liste,string token)
        {
            var url = $"{Constants.BaseUrlApi}Liste";
            Liste resultListe = await _httpService.SendHttpRequest<Liste>(url, HttpMethod.Post,liste,bearer: token);
            return resultListe;
        }
    }
}
