using Repo.IR;
using System;
using System.Collections.Generic;
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

        public void RemoveRange(List<Picture> pictures)
        {
            _db.Picture.RemoveRange(pictures);
            _db.SaveChanges();
        }
    }
}