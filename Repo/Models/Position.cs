using System.ComponentModel.DataAnnotations;

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