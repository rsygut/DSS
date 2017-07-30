using System.Web.Mvc;
using Repo.IR;
using Repo.Models;

namespace DSS.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPictureRepo _pictureRepo;

        public PictureController(IPictureRepo pictureRepo)
        {
            _pictureRepo = pictureRepo;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Edit", "Place", new { id = 1 });
        }

        public ActionResult Delete(int pictureId, int placeId)
        {
            _pictureRepo.Remove(pictureId);

            return RedirectToAction("Edit", "Place", new {id = placeId});
        }

        public ActionResult SetAsDefault(int pictureId, int placeId)
        {
            _pictureRepo.SetAsDefault(pictureId,placeId);
            return RedirectToAction("Edit", "Place", new { id = placeId });
        }
    }
}