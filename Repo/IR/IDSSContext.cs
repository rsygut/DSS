using Repo.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repo.IR
{
    public interface IDSSContext
    {
        DbSet<Comment> Comment { get; set; }
        DbSet<Picture> Picture { get; set; }
        DbSet<Place> Place { get; set; }
        DbSet<User> User { get; set; }
        DbEntityEntry Entry(object entity);

        int SaveChanges();
        Database Database { get; }

    }
}
