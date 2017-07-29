using Repo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IR
{
    public interface IDSSContext
    {
        DbSet<Access> Access { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Comment> Comment { get; set; }
        DbSet<Picture> Picture { get; set; }
        DbSet<Place> Place { get; set; }
        DbSet<Position> Position { get; set; }
        DbSet<RequiredPermission> RequiredPermission { get; set; }
        DbSet<User> User { get; set; }
        DbEntityEntry Entry(object entity);

        int SaveChanges();
        Database Database { get; }

    }
}
