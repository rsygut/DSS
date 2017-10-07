using System;

namespace Repo.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string PictureName { get; set; }
        public DateTime Created { get; set; }
        public bool IsDefault { get; set; }

        public virtual Place Place { get; set; }
    }
}