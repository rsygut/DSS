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
using System.IO;

namespace DSS.Controllers
{
    public class PlaceController : Controller
    {
        private DSSContext db = new DSSContext();

        // GET: Places
        public ActionResult Index()
        {
            db.Database.Log = message => Trace.WriteLine(message);
            var place = db.Place.AsNoTracking();
                //Include(p => p.Position).Include(p => p.User); przyspieszenie str323
            return View(place.ToList());
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Place.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Position, "Id", "Location");// tu tez moze byc problem
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Drive,Owner,Height,MaxDeep,Visibility,Danger,PlaceDescription,Logistic,FaunaAndFlora,AttractionDescribe,Other,GridX,GridY,UserId,file")] Place place, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {                
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/App_Data/Images/"), fileName);
                file.SaveAs(path);
                var picture = new Picture {PictureName = fileName,Created = DateTime.UtcNow};
                place.Picture.Add(picture); 

                db.Place.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Position, "Id", "Location", place.Id);// TU TEZ MOZE BYC ZLE
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", place.UserId);
            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Place.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Position, "Id", "Location", place.Id);// TU TEZ
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", place.UserId);
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Drive,Owner,Height,MaxDeep,Visibility,Danger,PlaceDescription,Logistic,FaunaAndFlora,AttractionDescribe,Other,GridX,GridY,UserId")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Position, "Id", "Location", place.Id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", place.UserId);
            return View(place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Place.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Place.Find(id);
            db.Place.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowPhoto(string dataId)
        {
            var dir = Server.MapPath("~/App_Data/Images/");
            var path = Path.Combine(dir, dataId);
            return File(path, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
