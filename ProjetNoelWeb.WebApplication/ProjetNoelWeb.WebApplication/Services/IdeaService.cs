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
            var url = $"{Constants.BaseUrlApi}/Idea?idListe={idListe}";
            var resultIdeas = await _httpService.SendHttpRequest<List<Idea>>(url, HttpMethod.Get, bearer: token);
            return resultIdeas;
        }
    }
}
