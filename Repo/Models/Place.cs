using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class Place
    {
        public Place()
        {
            ReguiredPermission = new Collection<RequiredPermission>(); // jaki to ma być typ relacji??
            Picture = new Collection<Picture>();
            Comment = new Collection<Comment>();
        }

        public int Id { get; set; }
        [DisplayName("Dojazd")]
        public string Drive { get; set; }
        [DisplayName("Właściciel")]
        public string Owner { get; set; }
        public int Height { get; set; }
        public double MaxDeep { get; set; }
        public double Visibility { get; set; }
        public string Danger { get; set; }
        public string PlaceDescription { get; set; }
        public string Logistic { get; set; }
        public string FaunaAndFlora { get; set; }
        public string AttractionDescribe { get; set; }
        public string Other { get; set; }
        public float GridX { get; set; }
        public float GridY { get; set; }
        public string UserId { get; set; } //proba dodani aid user do place
        // public DataType AddDate { get; set; }
        //one to one
        public virtual User User { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<RequiredPermission> ReguiredPermission { get; private set; }
        public virtual ICollection<Picture> Picture { get; private set; }
        public virtual ICollection<Comment> Comment { get; private set; }

        //1 kategoria moze miec wiele miejsc
        public virtual Category Category { get; set; }
        //wiele miejsc moze miec jeden dostep
        public virtual Access Access { get; set; }
    }
}