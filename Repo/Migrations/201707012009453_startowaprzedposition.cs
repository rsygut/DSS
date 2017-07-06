namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startowaprzedposition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Access",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Drive = c.String(),
                        Owner = c.String(),
                        Height = c.Int(nullable: false),
                        MaxDeep = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Visibility = c.Double(nullable: false),
                        Danger = c.String(),
                        PlaceDescription = c.String(),
                        Logistic = c.String(),
                        FaunaAndFlora = c.String(),
                        AttractionDescribe = c.String(),
                        Other = c.String(),
                        GridX = c.Single(nullable: false),
                        GridY = c.Single(nullable: false),
                        Access_Id = c.Int(),
                        Category_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Access", t => t.Access_Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Access_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        Created = c.DateTime(nullable: false),
                        Place_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Place", t => t.Place_Id)
                .Index(t => t.Place_Id);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureName = c.String(),
                        Creted = c.DateTime(nullable: false),
                        Place_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Place", t => t.Place_Id)
                .Index(t => t.Place_Id);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Place", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RequiredPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(),
                        Place_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Place", t => t.Place_Id)
                .Index(t => t.Place_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(),
                        Surname = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Place", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RequiredPermission", "Place_Id", "dbo.Place");
            DropForeignKey("dbo.Position", "Id", "dbo.Place");
            DropForeignKey("dbo.Picture", "Place_Id", "dbo.Place");
            DropForeignKey("dbo.Comment", "Place_Id", "dbo.Place");
            DropForeignKey("dbo.Place", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Place", "Access_Id", "dbo.Access");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RequiredPermission", new[] { "Place_Id" });
            DropIndex("dbo.Position", new[] { "Id" });
            DropIndex("dbo.Picture", new[] { "Place_Id" });
            DropIndex("dbo.Comment", new[] { "Place_Id" });
            DropIndex("dbo.Place", new[] { "User_Id" });
            DropIndex("dbo.Place", new[] { "Category_Id" });
            DropIndex("dbo.Place", new[] { "Access_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.RequiredPermission");
            DropTable("dbo.Position");
            DropTable("dbo.Picture");
            DropTable("dbo.Comment");
            DropTable("dbo.Category");
            DropTable("dbo.Place");
            DropTable("dbo.Access");
        }
    }
}
