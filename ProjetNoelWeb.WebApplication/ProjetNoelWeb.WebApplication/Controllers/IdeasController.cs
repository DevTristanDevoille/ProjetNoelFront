using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using ProjetNoelWeb.WebApplication.Commons;
using ProjetNoelWeb.WebApplication.Models;
using ProjetNoelWeb.WebApplication.Services.Interfaces;
using ProjetNoelWeb.WebApplication.ViewModels;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetNoelWeb.WebApplication.Controllers
{
    public class IdeasController : Controller
    {
        private readonly IIdeaService _ideaService;
        private readonly IListeService _listeService;

        public IdeasController(IIdeaService ideaService,IListeService listeService)
        {
            _ideaService = ideaService;
            _listeService = listeService;
        }

        public async Task<IActionResult> Index(int listeId)
        {
            if(listeId == 0 && Constants.idListe != 0)
            {
                listeId = Constants.idListe;
            }
            else
            {
                Constants.idListe = listeId;
            }
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(HttpContext.Request.Cookies["Token"]);
            JwtSecurityToken? tokenS = jsonToken as JwtSecurityToken;
            string result = tokenS.Claims.First(claim => claim.Type == "id").Value;
            var resultIdeas = await _ideaService.GetAllIdeas(listeId, HttpContext.Request.Cookies["Token"]);
            var resultLIste = await _listeService.GetListe(listeId, HttpContext.Request.Cookies["Token"]);

            IdeasViewModel model = new IdeasViewModel() { Ideas = resultIdeas, Liste = resultLIste,idUser = int.Parse(result) };

            return View(model);
        }

        public async Task<IActionResult> EditIdeas(List<string>? inputListName,List<string>? inputListUrl, List<string>? inputListPrice, List<string>? inputListPosition,List<bool>? inputIsTake)
        {
            List<Idea> ideas = new List<Idea>();
            Liste liste = await _listeService.GetListe(Constants.idListe, HttpContext.Request.Cookies["Token"]);

            for (int i = 0; i <= inputListPosition.Count()-1; i++)
            {
                ideas.Add(new Idea() { Position = i, Name = inputListName[i], Price = float.Parse(inputListPrice[i]), UrlIdea = inputListUrl[i],IdListe = liste.Id,IsTake = inputIsTake[i] });
            }

            var result = _ideaService.UpdateIdeas(ideas, HttpContext.Request.Cookies["Token"]);

            return RedirectToAction("Index","Ideas");
        }
    }
}
