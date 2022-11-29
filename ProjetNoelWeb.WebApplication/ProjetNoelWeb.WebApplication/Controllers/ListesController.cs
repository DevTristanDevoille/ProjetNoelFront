using Microsoft.AspNetCore.Mvc;
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
            var result = await _listeService.GetAllListes(squadId,HttpContext.Request.Cookies["Token"]);
            ListesViewModel model = new ListesViewModel() { Listes = result };
            return View(model);
        }
    }
}
