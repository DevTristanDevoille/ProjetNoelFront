using Microsoft.AspNetCore.Mvc;
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
    }
}
