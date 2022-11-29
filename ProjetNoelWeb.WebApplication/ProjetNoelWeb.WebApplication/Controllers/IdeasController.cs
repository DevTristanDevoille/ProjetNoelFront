using Microsoft.AspNetCore.Mvc;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class IdeasController : Controller
    {
        private readonly IIdeaService _ideaService;

        public IdeasController(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        public IActionResult Index(int listeId)
        {
            var result = _ideaService.GetAllIdeas(listeId, HttpContext.Request.Cookies["Token"]);
            return View();
        }
    }
}
