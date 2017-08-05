using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using System.Diagnostics;
using Repo.R;
using Repo.IR;
using Microsoft.AspNet.Identity;
using System.IO;

namespace DSS.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceRepo _repo;
        private readonly IPictureRepo _pictureRepo;

        public PlaceController(IPlaceRepo repo, IPictureRepo pictureRepo)
        {
            _repo = repo;
            _pictureRepo = pictureRepo;
        }

        // GET: Places
        public ActionResult Index()
        {
            var place = _repo.DownloadPlace();
            return View(place);
            //Include(p => p.Position).Include(p => p.User); przyspieszenie str323

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
            //ViewBag.Id = new SelectList(db.Position, "Id", "Location");// tu tez moze byc problem
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email"); lista uzytkownow przy dodaniu miejsca j=nie jest otrzebna
            // bo moze dodac tylko 1 str 353
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        //[Authorize] Do testow zakomentowalem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Drive,Owner,Height,MaxDeep,Visibility,Danger,PlaceDescription,Logistic,FaunaAndFlora,AttractionDescribe,Other,GridX,GridY,file,RequiredPermission")] Place place, HttpPostedFileBase file, string requiredPermission)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/App_Data/Images/"), fileName);
                    file.SaveAs(path);

                    var picture = new Picture { PictureName = fileName, Created = DateTime.Now, IsDefault = true };
                    place.Picture.Add(picture);
                }
                if (!String.IsNullOrWhiteSpace(requiredPermission))
                {
                    var permission = new RequiredPermission { PermissionName = requiredPermission, Place = place };
                    place.ReguiredPermission = permission;
                }
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Drive,Owner,Height,MaxDeep,Visibility,Danger,PlaceDescription,Logistic,FaunaAndFlora,AttractionDescribe,Other,GridX,GridY,UserId,file")] Place place, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/App_Data/Images/"), fileName);
                    file.SaveAs(path);
                    var picture = new Picture { PictureName = fileName, Created = DateTime.UtcNow };
                    _pictureRepo.AddPicture(picture);
                    place.Picture.Add(picture);

                    _repo.UpdatePlace(place);
                    _repo.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = true;
                    return View(place);
                }
            }
            ViewBag.Error = false;
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
            var path = Path.Combine(dir, dataId);
            return File(path, "image/jpeg");
        }
    }
}
