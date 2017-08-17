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
            Picture = new Collection<Picture>();
            Comment = new Collection<Comment>();
        }

        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Dojazd")]
        public string Drive { get; set; }
        [DisplayName("Właściciel")]
        public string Owner { get; set; }
        [DisplayName("Wysokość m.n.p.m")]
        public int Height { get; set; }
        [DisplayName("Głębokość")]
        public double MaxDeep { get; set; }
        [DisplayName("Widoczność")]
        public double Visibility { get; set; }
        [DisplayName("Niebezpieczeństwa")]
        public string Danger { get; set; }
        [DisplayName("Opis miejsca")]
        public string PlaceDescription { get; set; }
        [DisplayName("Logistyka")]
        public string Logistic { get; set; }
        [DisplayName("Fauna i Flora")]
        public string FaunaAndFlora { get; set; }
        [DisplayName("Opis atrakcji")]
        public string AttractionDescribe { get; set; }
        [DisplayName("Inne")]
        public string Other { get; set; }
        public float GridX { get; set; }
        public float GridY { get; set; }
        public string UserId { get; set; } //proba dodani aid user do place
       // [DisplayName("Data dodania")]
       // public DateTime AddDate { get; set; }
        //one to one
        public virtual User User { get; set; }

        public virtual Position Position { get; set; }
        public virtual RequiredPermission ReguiredPermission { get; set; }
        public virtual ICollection<Picture> Picture { get; private set; }
        public virtual ICollection<Comment> Comment { get; private set; }

        //1 kategoria moze miec wiele miejsc
        public virtual Category Category { get; set; }
        //wiele miejsc moze miec jeden dostep
        public virtual Access Access { get; set; }

        
    }
}