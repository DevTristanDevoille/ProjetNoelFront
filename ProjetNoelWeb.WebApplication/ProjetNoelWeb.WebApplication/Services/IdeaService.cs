using ProjetNoelWeb.WebApplication.Commons;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

namespace ProjetNoelWeb.WebApplication.Services
{
    public class IdeaService : IIdeaService
    {
        #region privates
        private readonly IHttpService _httpService;
        #endregion

        #region CTOR
        public IdeaService(IHttpService httpService)
        {
            _httpService = httpService;

        }
        #endregion

        public async Task<List<Idea>> GetAllIdeas(int idListe, string token)
        {
            string url = $"{Constants.BaseUrlApi}Idea?idListe={idListe}";
            List<Idea> resultIdeas = await _httpService.SendHttpRequest<List<Idea>>(url, HttpMethod.Get, bearer: token);
            return resultIdeas;
        }

        public async Task<List<Idea>> UpdateIdeas(List<Idea> ideas, string token)
        {
            string url = $"{Constants.BaseUrlApi}Idea";
            List<Idea> resultIdeas = await _httpService.SendHttpRequest<List<Idea>>(url, HttpMethod.Put,ideas, bearer: token);
            return resultIdeas;
        }

        public async Task<List<Idea>> CreateIdeas(List<Idea> ideas, string token)
        {
            string url = $"{Constants.BaseUrlApi}Idea";
            List<Idea> resultIdeas = await _httpService.SendHttpRequest<List<Idea>>(url, HttpMethod.Post, ideas, bearer: token);
            return resultIdeas;
        }
    }
}
