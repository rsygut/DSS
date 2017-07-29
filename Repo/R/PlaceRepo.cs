using Repo.IR;
using Repo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Repo.R
{
    public class PlaceRepo : IPlaceRepo
    {

        private readonly IDSSContext _db;
        public PlaceRepo(IDSSContext db)
        {
            _db = db;
        }


        public IQueryable<Place> DownloadPlace()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            var place = _db.Place.AsNoTracking();
            return place;
        }

        public Place GetPlaceById(int id)
        {
            Place place = _db.Place.Find(id);
            return place;
        }
        //348 kaskadowe usuwanie
        public bool DeletePlace(int id)
        {
            Place place = _db.Place.Find(id);
            _db.Place.Remove(place);
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public void AddPlace(Place place)
        {
            _db.Place.Add(place);
        }

        //kod po aktualizacji
        //public void DeletePlace(int id)
        //{
        //    Place place = _db.Place.Find(id);
        //    _db.Place.Remove(place);

        //}

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void UpdatePlace(Place place)
        {
            _db.Entry(place).State = EntityState.Modified;
        }
    }
}