using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class Position
    {
        public int Id { get; set; }
        //jak zrobic lokazlizacje???
        public string Location { get; set; }

        [Required]
        public virtual Place Place { get; set; }
    }
}