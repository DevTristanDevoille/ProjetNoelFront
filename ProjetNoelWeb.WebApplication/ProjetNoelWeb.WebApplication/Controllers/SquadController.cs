using Microsoft.AspNetCore.Mvc;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class SquadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
