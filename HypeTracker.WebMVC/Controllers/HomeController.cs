using HypeTracker.Models;
using HypeTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HypeTracker.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeService service = new HomeService();
            HomeModel model = new HomeModel()
            {
                topMovie = service.GetTopMovie(),
                topGame = service.GetTopGame(),
                topShow = service.GetTopShow()
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}