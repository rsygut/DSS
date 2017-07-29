using Repo.IR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlaceRepo _placeRepo;

        public HomeController(IPlaceRepo placeRepo)
        {
            _placeRepo = placeRepo;
        }
        public ActionResult Index()
        {
            return View(_placeRepo.DownloadPlace());
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