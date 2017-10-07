using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using Repo.IR;
using Microsoft.AspNet.Identity;
using DSS.Services;

namespace DSS.Controllers
{
    public class PlaceController : Controller
    {
        private const int MaxImageSize = 2000000;

        private readonly IPlaceRepo _repo;
        private readonly IPictureRepo _pictureRepo;
        private readonly IGeocodingService _geocodingService;

        public PlaceController(IPlaceRepo repo, IPictureRepo pictureRepo, IGeocodingService geocodingService)
        {
            _repo = repo;
            _pictureRepo = pictureRepo;
            _geocodingService = geocodingService;
        }

        // GET: Places
        public ActionResult Index()
        {
            var place = _repo.DownloadPlace();
            return View(place);

        }

        //GET: Places/Details/5
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

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[Authorize] Do testow zakomentowalem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Place place, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {   
                if (file != null)
                {
                    if (file.ContentLength > MaxImageSize)
                    {
                        ModelState.AddModelError(string.Empty, "Rozmiar obrazka nie może być większy, niż 2mb");
                        return View(place);
                    }

                    var fileName = Guid.NewGuid().ToString();
                    var path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), fileName);
                    file.SaveAs(path);

                    var picture = new Picture { PictureName = fileName, Created = DateTime.UtcNow, IsDefault = true };
                    place.Picture.Add(picture);
                }

                var localization = _geocodingService.GetLocalizationForPlace(place.Name);
                place.County = localization.County;
                place.Province = localization.Province;
                place.Latitude = localization.Latitude;
                place.Longitude = localization.Longitude;

                place.AddDate = DateTime.UtcNow;
                place.UserId = User.Identity.GetUserId();
                _repo.AddPlace(place);   //test dodawania str 356
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = _repo.GetPlaceById((int)(id));
            if (place == null)
            {
                return HttpNotFound();
            }

            return View(place);
        }

        // POST: Places/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Place place, HttpPostedFileBase file = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        if (file.ContentLength > MaxImageSize)
                        {
                            ModelState.AddModelError(string.Empty, "Rozmiar obrazka nie może być większy, niż 2mb");
                            return View(place);
                        }

                        var fileName = Guid.NewGuid().ToString();
                        var path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), fileName);
                        file.SaveAs(path);
                        var picture = new Picture { PictureName = fileName, Created = DateTime.UtcNow };
                        _pictureRepo.AddPicture(picture);
                        place.Picture.Add(picture);
                    }

                    _repo.UpdatePlace(place);
                    _repo.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = true;
                    return View(place);
                }
            }
            TempData["Success"] = false;
            return RedirectToAction("Edit", place.Id);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id, bool? error)
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
            if (error != null)
            {
                ViewBag.Error = true;
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        // zamiana 
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.DeletePlace(id);

            try
            {
                _repo.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, error = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult ShowPhoto(string dataId)
        {
            if (dataId == null)
                return null;
            var dir = Server.MapPath("~/App_Data/Images/");
            var path = System.IO.Path.Combine(dir, dataId);
            return File(path, "image/jpeg");
        }
    }
}
