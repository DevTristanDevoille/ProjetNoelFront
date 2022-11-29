using Microsoft.AspNetCore.Mvc;
using ProjetNoelWeb.WebApplication.Commons;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class ListeController : Controller
    {
        private readonly IListeService _listeService;

        public ListeController(IListeService listeService)
        {
            _listeService = listeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateListe(Liste liste)
        {
            liste.IdSquad = Constants.idSquad;
            var creation = await _listeService.CreateListe(liste, HttpContext.Request.Cookies["Token"]);
            return RedirectToAction("Index", "Listes");
        }
    }
}
