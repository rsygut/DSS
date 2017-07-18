namespace Repo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Repo.Models.DSSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repo.Models.DSSContext context)
        {
            //Do debugowania metody seed
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SeedRoles(context);
            SeedUsers(context);
            SeedAccess(context);
            SeedCategory(context);
            SeedComment(context);
            SeedPicture(context);
            SeedPlace(context);
            SeedPosition(context); // blad
            SeedRequiredPermission(context); 

        }

        private void SeedRoles(DSSContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>
                (new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }


        private void SeedUsers(DSSContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new User { UserName = "Admin" };

                var adminresult = manager.Create(user, "12345678");

                if (adminresult.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }
        }

        private void SeedAccess(DSSContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var acc = new Access()
                {
                    Id = i,
                    Name = "nazwa dostepu" + i.ToString(),
                };
                context.Set<Access>().AddOrUpdate(acc);
            }
            context.SaveChanges();
        }

        private void SeedCategory(DSSContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                var cat = new Category()
                {
                    Id = i,
                    CategoryName = "nazwa kategori" + i.ToString(),
                };
                context.Set<Category>().AddOrUpdate(cat);
            }
            context.SaveChanges();
        }

        private void SeedComment(DSSContext context)
        {
            for (int i = 0; i <5; i++)
            {
                var com = new Comment()
                {
                    Id = i,
                    CommentText = "Tresc komentarza" + i.ToString(),
                    Created = DateTime.Now.AddDays(-i)
                };
                context.Set<Comment>().AddOrUpdate(com);
            }
            context.SaveChanges();
        }

        private void SeedPicture(DSSContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var pic = new Picture()
                {
                    Id = i,
                    PictureName = "Nazwa zdjecia" + i.ToString(),
                    Created = DateTime.Now.AddDays(-i)
                };
                context.Set<Picture>().AddOrUpdate(pic);
            }
            context.SaveChanges();
        }

        private void SeedPlace(DSSContext context)
        {
            var idUser = context.Set<User>()
                .Where(u => u.UserName == "Admin")
                .FirstOrDefault().Id;
            /// Nie mam USER ID !!!!!!
            ///  public int Id { get; set; }
            //public string Drive { get; set; }
            //public string Owner { get; set; }
            //public int Height { get; set; }
            //public decimal MaxDeep { get; set; }
            //public double Visibility { get; set; }
            //public string Danger { get; set; }
            //public string PlaceDescription { get; set; }
            //public string Logistic { get; set; }
            //public string FaunaAndFlora { get; set; }
            //public string AttractionDescribe { get; set; }
            //public string Other { get; set; }
            //public float GridX { get; set; }
            //public float GridY { get; set; }
            for (int i = 0; i < 10; i++)
            {
                var pla = new Place()
                {
                    Id = i,
                    UserId= idUser, //jak przypisac id uzytkownika do omiejsca proba
                    Drive = "Opis dojazdu" + i.ToString(),
                    Owner = "Opis w³aœciciela" + i.ToString(),
                    Height = 320 + i,
                    MaxDeep = 20 + i,
                    Visibility = i,
                    Danger = "Opis niebezpieczenstwa" + i.ToString(),
                    PlaceDescription = "Opis miejsca" + i.ToString(),
                    Logistic = "Opis logistyki" + i.ToString(),
                    FaunaAndFlora = "Opis fauny i flory" + i.ToString(),
                    AttractionDescribe = "Opis Atrakcji" + i.ToString(),
                    Other = "Opis innych rzeczy" + i.ToString(),
                    GridX = 23 + i,
                    GridY = 46 + i




                };
                context.Set<Place>().AddOrUpdate(pla);
            }
            context.SaveChanges();

        }
        private void SeedPosition(DSSContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var pos = new Position()
                {
                    Place = new Place(),
                    Location = "Lokalizacja" + i.ToString()
                    
                    //dodac w seedzie cos z required place
                };
                context.Set<Position>().AddOrUpdate(pos);
            }
            context.SaveChanges();
        }


        private void SeedRequiredPermission(DSSContext context)
        {
            for (int i = 0; i < 3; i++)
            {
                var req = new RequiredPermission()
                {
                    Id = i,
                    PermissionName = "Wymagane uprawnienie" + i.ToString()
                };
                context.Set<RequiredPermission>().AddOrUpdate(req);
            }
            context.SaveChanges();

        }



    }
}
