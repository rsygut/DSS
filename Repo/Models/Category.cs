using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class Category
    {
        public Category()
        {
            this.Place = new HashSet<Place>();
        }
        public int Id { get; set; }

        [DisplayName("Kategoria")]
        public string CategoryName { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }
}