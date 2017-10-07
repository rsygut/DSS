using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Repo.IR;

namespace Repo.Models
{
    public class DSSContext : IdentityDbContext, IDSSContext
    {
        public DSSContext()
            : base("DSS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DSSContext>());
        }
        public static DSSContext Create()
        {
            return new DSSContext();
        }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<User> User { get; set; }
    }
}