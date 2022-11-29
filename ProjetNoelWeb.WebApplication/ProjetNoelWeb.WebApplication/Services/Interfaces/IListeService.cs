using ProjetNoelWeb.WebApplication.Models;

namespace ProjetNoelWeb.WebApplication.Services.Interfaces
{
    public interface IListeService
    {
        public Task<List<Liste>> GetAllListes(int idSquad,string token); 
    }
}
