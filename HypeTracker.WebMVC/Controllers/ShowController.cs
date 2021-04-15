using HypeTracker.Data;
using HypeTracker.Data.Classes;
using HypeTracker.Models.MovieModels;
using HypeTracker.Models.ShowModels;
using HypeTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HypeTracker.WebMVC.Controllers
{
    public class ShowController : Controller
    {
        // GET: All Shows
        public ActionResult AllShows()
        {
            ShowService service = new ShowService();
            IEnumerable<ShowListItem> allShows = service.GetAllShows();

            return View(allShows);
        }

        public ActionResult Search(string title)
        {
            ShowService service = new ShowService();
            IEnumerable<ShowListItem> showSearch = service.GetShowsByTitle(title);

            return View(showSearch);
        }

        // GET: Create Show
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowCreate model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not add show, please make sure all fields are filled");
                return View(model);
            }

            ShowService service = new ShowService();

            if (service.CreateShow(model))
            {
                return RedirectToAction("AllShows");
            }

            return View(model);
        }

        // GET: Show Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ShowService service = new ShowService();
            ShowDetail show = service.GetShowById(id);

            return View(show);

        }

        // GET: Delete Show
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            ShowService service = new ShowService();
            ShowDetail show = service.GetShowById(id);

            return View(show);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShow(int id)
        {
            ShowService service = new ShowService();

            service.DeleteShow(id);

            return RedirectToAction("AllShows");
        }

        // GET: Edit Movie
        public ActionResult Edit(int? id)
        {
            ShowService service = new ShowService();
            ShowDetail detail = service.GetShowById(id);

            ShowEdit show = new ShowEdit()
            {
                Id = detail.Id,
                Title = detail.Title,
                Description = detail.Description,
                PosterUrl = detail.PosterUrl,
                NextReleaseDate = detail.NextReleaseDate,
                Franchise = detail.Franchise,
                AnticipationValue = detail.AnticipationValue
            };

            return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShowEdit model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not update show, try again later");
                return View(model);
            }

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }

            ShowService service = new ShowService();

            if (service.UpdateShow(model))
            {
                return RedirectToAction("AllShows");
            }

            ModelState.AddModelError("", "Could not update show, try again later");
            return View(model);
        }
    }
}