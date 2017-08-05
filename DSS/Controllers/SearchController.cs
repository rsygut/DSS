using DSS.Models.View;
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
            return View(new SearchViewModel());
        }

        public ActionResult Search([Bind(Include = "Name,Depth,Visibility,Permission")]SearchViewModel search)
        {
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
                    query=query.Where(x => x.ReguiredPermission.PermissionName == search.Permission.ToString());
                }
                search.Places = query.AsEnumerable();

                return View("Index", search);
            }

            return View("Index",search);
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