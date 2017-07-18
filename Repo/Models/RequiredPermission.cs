using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class RequiredPermission
    {
      
        public int Id { get; set; }

        public string PermissionName { get; set; }

        public Place Place { get; set; }
    }
}