using Newtonsoft.Json.Linq;
using ProjetNoelWeb.WebApplication.Models;

namespace ProjetNoelWeb.WebApplication.Services.Interfaces
{
    public interface ISquadService
    {
        public Task<IEnumerable<Squad>> GetAllSquad(string token);
        public Task<Squad> CreateSquad(string name,string token);
        public Task<bool> JoinSquad(string code,string token);
    }
}
