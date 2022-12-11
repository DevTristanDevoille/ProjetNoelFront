using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public IdeasController(IIdeaService ideaService, IListeService listeService)
        {
            _ideaService = ideaService;
            _listeService = listeService;
        }

        public async Task<IActionResult> Index(int listeId)
        {
            if (listeId == 0 && Constants.idListe != 0)
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
            var resultListe = await _listeService.GetListe(listeId, HttpContext.Request.Cookies["Token"]);

            IdeasViewModel model = new IdeasViewModel() { Ideas = resultIdeas.OrderBy(i => i.Position), Liste = resultListe, idUser = int.Parse(result) };

            return View(model);
        }

        public async Task<IActionResult> EditIdeas(List<string>? inputListName, List<string>? inputListUrl, List<string>? inputListPrice, List<string>? inputListPosition, List<string>? inputIsTake, List<string>? inputListId, List<string>? inputIdTake, List<string>? textAreaCommentaire)
        {
            List<Idea> newIdeas = new List<Idea>();
            List<Idea> updateIdeas = new List<Idea>();
            Liste liste = await _listeService.GetListe(Constants.idListe, HttpContext.Request.Cookies["Token"]);
            List<Idea> actualIdeas = await _ideaService.GetAllIdeas(liste.Id, HttpContext.Request.Cookies["Token"]);
            List<string> listIsTake = new List<string>();

            for (int j = 1; j <= inputListId.Count(); j++)
            {
                listIsTake.Add("False");
            }

            foreach (var item in inputIdTake)
            {
                listIsTake[int.Parse(item)-1] = "True";
            }

            for (int i = 0; i <= inputListPosition.Count() - 1; i++)
            {
                if (inputListPrice[i] != null)
                {
                    inputListPrice[i] = inputListPrice[i].Replace("Prix : ", "");
                    inputListPrice[i] = inputListPrice[i].Replace(" €", "");
                }

                if (inputListUrl[i] != null)
                    inputListUrl[i] = inputListUrl[i].Replace("Lien vers l'idée : ", "");

                if (inputListPosition[i] != null)
                    inputListPosition[i] = inputListPosition[i].Replace("Ordre de préférence : ", "");

                Idea idea = new Idea();

                if (inputListId[i] != null)
                {
                    if (listIsTake[i] == "False")
                    {
                        if (inputListPrice[i] != null && inputListPrice[i] != "€")
                            idea = new Idea() { Position = int.Parse(inputListPosition[i]), Name = inputListName[i], Price = float.Parse(inputListPrice[i]), UrlIdea = inputListUrl[i], IsTake = false, IdListe = liste.Id, Id = int.Parse(inputListId[i]), Commentaire = textAreaCommentaire[i] };
                        else
                            idea = new Idea() { Position = int.Parse(inputListPosition[i]), Name = inputListName[i], UrlIdea = inputListUrl[i], IsTake = false, IdListe = liste.Id, Id = int.Parse(inputListId[i]),Commentaire = textAreaCommentaire[i] };

                        updateIdeas.Add(idea);
                    }
                    else
                    {
                        if (inputListPrice[i] != null && inputListPrice[i] != "€")
                            idea = new Idea() { Position = int.Parse(inputListPosition[i]), Name = inputListName[i], Price = float.Parse(inputListPrice[i]), UrlIdea = inputListUrl[i], IsTake = true, IdListe = liste.Id, Id = int.Parse(inputListId[i]), Commentaire = textAreaCommentaire[i] };
                        else
                            idea = new Idea() { Position = int.Parse(inputListPosition[i]), Name = inputListName[i], UrlIdea = inputListUrl[i], IsTake = true, IdListe = liste.Id, Id = int.Parse(inputListId[i]), Commentaire = textAreaCommentaire[i] };

                        updateIdeas.Add(idea);
                    }
                }
                else
                {
                    if (inputIsTake[i] == "False")
                        if (inputListPrice[i] != null && inputListPrice[i] != "€")
                            idea = new Idea() { Position = int.Parse(inputListPosition[i]), Name = inputListName[i], Price = float.Parse(inputListPrice[i]), UrlIdea = inputListUrl[i], IsTake = false, IdListe = liste.Id, Commentaire = "" };
                        else
                            idea = new Idea() { Position = int.Parse(inputListPosition[i]), Name = inputListName[i], UrlIdea = inputListUrl[i], IsTake = false, IdListe = liste.Id, Commentaire = "" };
                    //else
                    //    if(inputListPrice[i] != null && inputListPrice[i] != "€")
                    //        idea = new Idea() { Position = i, Name = inputListName[i], Price = float.Parse(inputListPrice[i]), UrlIdea = inputListUrl[i], IsTake = true, IdListe = liste.Id };
                    //    else
                    //        idea = new Idea() { Position = i, Name = inputListName[i], UrlIdea = inputListUrl[i], IsTake = true, IdListe = liste.Id };
                    newIdeas.Add(idea);
                }

            }


            if (newIdeas.Count != 0 || newIdeas != null)
            {
                var resultCreate = await _ideaService.CreateIdeas(newIdeas, HttpContext.Request.Cookies["Token"]);
            }

            if (updateIdeas != null || updateIdeas.Count != 0)
            {
                foreach (var actualIdea in actualIdeas)
                {
                    foreach (var updateIdea in updateIdeas)
                    {
                        if (updateIdea.Id == actualIdea.Id && actualIdea.IsTake == true)
                            updateIdea.IsTake = true;
                    }
                }

                var resultUpdate = await _ideaService.UpdateIdeas(updateIdeas, HttpContext.Request.Cookies["Token"]);
            }

            return RedirectToAction("Index", "Ideas");
        }
    }
}
