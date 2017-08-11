using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class Access
    {
        public Access()
        {
            this.Place = new HashSet<Place>();
        }
        public int Id { get; set; }

        [DisplayName("Dostęp")]
        public string Name { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }

}