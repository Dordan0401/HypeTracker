using HypeTracker.Data;
using HypeTracker.Data.Classes;
using HypeTracker.Models.GameModels;
using HypeTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HypeTracker.WebMVC.Controllers
{
    public class GameController : Controller
    {
        // GET: All Games
        public ActionResult AllGames()
        {
            GameService service = new GameService();
            IEnumerable<GameListItem> allGames = service.GetAllGames();

            return View(allGames);
        }

        public ActionResult Search(string title)
        {
            GameService service = new GameService();
            IEnumerable<GameListItem> gameSearch = service.GetGamesByTitle(title);

            return View(gameSearch);
        }

        // GET: Create Game
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not add game, please make sure all fields are filled");
                return View(model);
            }

            GameService service = new GameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = $"{model.Title} was added successfully!";
                return RedirectToAction("AllGames");
            }

            return View(model);
        }

        // GET: Game Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GameService service = new GameService();
            GameDetail game = service.GetGameById(id);

            return View(game);

        }

        // GET: Delete Game
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            GameService service = new GameService();
            GameDetail game = service.GetGameById(id);

            return View(game);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int id)
        {
            GameService service = new GameService();

            service.DeleteGame(id);

            return RedirectToAction("AllGames");
        }

        // GET: Edit Game
        public ActionResult Edit(int? id)
        {
            GameService service = new GameService();
            GameDetail detail = service.GetGameById(id);

            GameEdit game = new GameEdit()
            {
                Id = detail.Id,
                Title = detail.Title,
                Description = detail.Description,
                ReleaseDate = detail.ReleaseDate,
                DevStudio = detail.DevStudio,
                AnticipationValue = detail.AnticipationValue
            };

            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not update game, try again later");
                return View(model);
            }

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }

            GameService service = new GameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = $"{model.Title} was updated";
                return RedirectToAction("AllGames");
            }

            ModelState.AddModelError("", "Could not update game, try again later");
            return View(model);
        }
    }
}