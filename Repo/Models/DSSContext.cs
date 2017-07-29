using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repo.IR;

namespace Repo.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   

    public class DSSContext : IdentityDbContext, IDSSContext
    {
        public DSSContext()
            : base("DefaultConnection")

            //  tu mozna zmienic nazwe do sql
        {
        }

        public static DSSContext Create()
        {
            return new DSSContext();
        }

        public DbSet<Access> Access { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<RequiredPermission> RequiredPermission { get; set; }
        public DbSet<User> User { get; set; }
 

        //wyłaczenie nadpisania nazw tabel jako liczby mnogiej
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //potrzebne dla klasy Identity
            base.OnModelCreating(modelBuilder);
            //wyłącza konwencje która tworzy automatycznie liczbę mnogą dla nazw tabel w Bazie Danych
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //wyłącza konwencje CascadeDelete
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Uzywa sie Fluent API, aby ustalić powiązanie pomiędzy tabelami i włączyć Cascade Delete dla tgo powiązania
        //    modelBuilder.Entity<Ogloszenie>().HasRequired
        //        (x => x.Uzytkownik).WithMany(x => x.Ogloszenia)
        //        .HasForeignKey(x => x.UzytkownikId).WillCascadeOnDelete(true);
        //}
        }
    }
}