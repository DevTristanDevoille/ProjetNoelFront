using ProjetNoelWeb.WebApplication.Models;

namespace ProjetNoelWeb.WebApplication.Services.Interfaces
{
    public interface IIdeaService
    {
        public Task<List<Idea>> GetAllIdeas(int idListe, string token);
    }
}
