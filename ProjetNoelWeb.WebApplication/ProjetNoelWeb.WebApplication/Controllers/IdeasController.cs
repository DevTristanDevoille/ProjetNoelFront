using Microsoft.AspNetCore.Mvc;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class IdeasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
