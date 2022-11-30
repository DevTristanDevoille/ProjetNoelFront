using ProjetNoelWeb.WebApplication.Models;

namespace ProjetNoelWeb.WebApplication.Services.Interfaces
{
    public interface IIdeaService
    {
        public Task<List<Idea>> GetAllIdeas(int idListe, string token);
        public Task<List<Idea>> UpdateIdeas(List<Idea> ideas,string token);
        public Task<List<Idea>> CreateIdeas(List<Idea> ideas, string token);
    }
}
