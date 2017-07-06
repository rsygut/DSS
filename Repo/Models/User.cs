using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Repo.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Places = new HashSet<Place>();// tu zrobić porządek bo zrobione na czuja

        }


        //klucz podstawowy odziedziczony po klasie IdentityUser
        public string Name { get; set; }
        public string Surname { get; set; }

        #region Additional field not mapped
        [NotMapped]
        [Display(Name = "Mr/Ms: ")]
        public string  FullName
        {
            get { return Name + " " + Surname; }
        }
        #endregion

        // proba kluczy

            public virtual ICollection<Place> Places
        { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;


        }
    }
}