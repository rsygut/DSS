﻿using System;
using System.Collections.Generic;
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
            ReguiredPermission = new List<RequiredPermission>();
            Picture = new List<Picture>();
            Comment = new List<Comment>();
        }

        public int Id { get; set; }
        public string Drive { get; set; }
        public string Owner { get; set; }
        public int Height { get; set; }
        public decimal MaxDeep { get; set; }
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

        //one to one
        public virtual User User { get; set; }
        
        public virtual Position Position { get; set; }
        //one to many
        public virtual ICollection <RequiredPermission>ReguiredPermission { get; private set; }
        public virtual ICollection<Picture> Picture { get; private set; }
        public virtual ICollection<Comment> Comment { get; private set; }

    //1 kategoria moze miec wiele miejsc
    public Category Category { get; set; }
        //wiele miejsc moze miec jeden dostep
        public Access Access { get; set; }
    }
}