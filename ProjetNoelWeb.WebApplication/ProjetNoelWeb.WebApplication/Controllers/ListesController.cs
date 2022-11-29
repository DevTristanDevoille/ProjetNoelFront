using Microsoft.AspNetCore.Mvc;
using ProjetNoelWeb.WebApplication.Commons;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;
using ProjetNoelWeb.WebApplication.ViewModels;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class ListesController : Controller
    {
        private readonly IListeService _listeService;

        public ListesController(IListeService listeService)
        {
            _listeService = listeService;
        }

        public async Task<IActionResult> Index(int squadId)
        {
            if(squadId == 0 && Constants.idSquad != 0)
            {
                squadId = Constants.idSquad;
            }
            else
                Constants.idSquad = squadId;
            var result = await _listeService.GetAllListes(squadId,HttpContext.Request.Cookies["Token"]);
            ListesViewModel model = new ListesViewModel() { Listes = result };
            return View(model);
        }

        public async Task<IActionResult> RetourIdeas()
        {
            List<Liste> result = await _listeService.GetAllListes(Constants.idSquad, HttpContext.Request.Cookies["Token"]);
            ListesViewModel model = new ListesViewModel() { Listes = result };
            return View("Index",model);
        }
    }
}
