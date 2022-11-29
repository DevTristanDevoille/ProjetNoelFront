using Microsoft.AspNetCore.Mvc;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class SquadController : Controller
    {
        private readonly ISquadService _squadService;

        public SquadController(ISquadService squadService)
        {
            _squadService = squadService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateSquad(Squad squad)
        {
            var creation = await _squadService.CreateSquad(squad.Name,HttpContext.Request.Cookies["Token"]);
            return RedirectToAction("Index","Squads");  
        }
    }
}
