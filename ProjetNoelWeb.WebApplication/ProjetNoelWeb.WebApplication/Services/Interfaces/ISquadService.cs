using ProjetNoelWeb.WebApplication.Models;

namespace ProjetNoelWeb.WebApplication.Services.Interfaces
{
    public interface ISquadService
    {
        public Task<IEnumerable<Squad>> GetAllSquad(string token);
    }
}
