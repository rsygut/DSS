using System.Web.Mvc;
using Repo.Models;

namespace DSS.Controllers
{
    public class HomeController : Controller
    {
        private DSSContext db = new DSSContext();

        public ActionResult Index()
        {
            var places = db.Place;
            return View(places);
        }
    }
}