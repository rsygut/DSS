using DSS.Models.View;
using DSS.Services;
using Repo.IR;
using Repo.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DSS.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPlaceRepo _repo;

        public SearchController(IPlaceRepo repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View(new SearchViewModel
            {
                Counties = _repo.GetAllCounties(),
                Provincies = _repo.GetAllProvincies()
            });
        }

        public ActionResult Search(SearchViewModel search)
        {
            search.Provincies = _repo.GetAllProvincies();
            search.Counties = _repo.GetAllCounties();

            if (ModelState.IsValid)
            {
                var query = _repo.DownloadPlace();
                if (!string.IsNullOrWhiteSpace(search.Name))
                {
                    query=query.Where(x => x.Name.Contains(search.Name));
                }
                if (search.Depth > 0)
                {
                    query=query.Where(x => x.MaxDeep >= search.Depth);
                }
                if (search.Visibility > 0)
                {
                    query=query.Where(x => x.Visibility >= search.Visibility);
                }
                if (search.Permission != null)
                {
                    query=query.Where(x => x.ReguiredPermission == search.Permission);
                }
                if (search.Access != null)
                {
                    query = query.Where(x => x.Access == search.Access);
                }
                if (search.Category != null)
                {
                    query = query.Where(x => x.Category == search.Category);
                }
                if (!string.IsNullOrWhiteSpace(search.Province))
                {
                    query = query.Where(x => x.Province == search.Province);
                }

                if (!string.IsNullOrWhiteSpace(search.County))
                {
                    query = query.Where(x => x.County == search.County);
                }
                search.Places = query.AsEnumerable();
            }

            return View("Index", search);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = _repo.GetPlaceById((int)id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }
    }
}