using Microsoft.AspNetCore.Mvc;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;
using ProjetNoelWeb.WebApplication.ViewModels;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class SquadsController : Controller
    {
        private readonly ISquadService _squadService;

        public SquadsController(ISquadService squadService)
        {
            _squadService = squadService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Squad> squads = await _squadService.GetAllSquad(HttpContext.Request.Cookies["Token"]);
            SquadsViewModel model = new SquadsViewModel { Squades = squads };
            return View(model);
        }

        public IActionResult JoinPageSquad()
        {
            return this.View("JoinSquad");
        }

        public async Task<IActionResult> JoinSquad(Squad squad)
        {
            var result = await _squadService.JoinSquad(squad.Code, HttpContext.Request.Cookies["Token"]);
            return RedirectToAction("Index", "Squads");
        }
    }
}
