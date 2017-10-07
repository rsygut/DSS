namespace Repo.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //internal sealed class Configuration : DbMigrationsConfiguration<Repo.Models.DSSContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }

    //    protected override void Seed(Repo.Models.DSSContext context)
    //    {
    //       // SeedRoles(context);
    //        //SeedUsers(context);
    //        //  This method will be called after migrating to the latest version.

    //        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
    //        //  to avoid creating duplicate seed data. E.g.
    //        //
    //        //    context.People.AddOrUpdate(
    //        //      p => p.FullName,
    //        //      new Person { FullName = "Andrew Peters" },
    //        //      new Person { FullName = "Brice Lambson" },
    //        //      new Person { FullName = "Rowan Miller" }
    //        //    );
    //        //
    //    }
    //    private void SeedRoles (DSSContext context)
    //    {
    //        var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>
    //            (new RoleStore<IdentityRole>());

    //        if (!roleManager.RoleExists("Admin"))
    //        {
    //            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
    //            role.Name = "Admin";
    //            roleManager.Create(role);
    //        }

    //    }

    //    private void SeedUsers(DSSContext context)
    //    {
    //        var store = new UserStore<User>(context);
    //        var manager = new UserManager<User>(store);
    //        if (!context.User.Any(u => u.UserName == "Admin"))
    //        {
    //            var user = new User { UserName = "Admin" };
    //            var adminresult = manager.Create(user, "12345678");

    //            if (adminresult.Succeeded)
    //                manager.AddToRole(user.Id, "Admin");
    //        }
                
    //    }
    //}
}
