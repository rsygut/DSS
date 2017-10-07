using System.ComponentModel.DataAnnotations;

namespace Repo.Models
{
    public enum Access
    {
        [Display(Name = "Z brzegu")]
        Z_brzegu,
        [Display(Name = "Z łodzi")]
        Z_łodzi
    }
}