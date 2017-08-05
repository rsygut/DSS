using System.ComponentModel.DataAnnotations;

namespace Repo.Models
{
    public class RequiredPermission
    {      
        public int Id { get; set; }
        public string PermissionName { get; set; }
        [Required]
        public virtual Place Place { get; set; }
    }
}