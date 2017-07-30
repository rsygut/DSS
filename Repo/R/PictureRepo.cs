using Repo.IR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Repo.Models;

namespace Repo.R
{
    public class PictureRepo : IPictureRepo
    {
        private readonly IDSSContext _db;
        public PictureRepo(IDSSContext db)
        {
            _db = db;
        }

        public void AddPicture(Picture picture)
        {
            _db.Picture.Add(picture);
        }

        public void Remove(int pictureId)
        {
            _db.Picture.Remove(_db.Picture.FirstOrDefault(x => x.Id == pictureId));
      
            _db.SaveChanges();
        }

        public void SetAsDefault(int pictureId, int placeId)
        {
            _db.Picture.Where(x => x.Place.Id == placeId).ToList().ForEach(y =>
            {
                y.IsDefault = y.Id == pictureId;
            });
            _db.SaveChanges();
        }

        public void RemoveRange(List<Picture> pictures)
        {
            _db.Picture.RemoveRange(pictures);
            _db.SaveChanges();
        }
    }
}