namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawaRequiredPermission : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequiredPermission", "Place_Id", "dbo.Place");
            DropIndex("dbo.RequiredPermission", new[] { "Place_Id" });
            CreateTable(
                "dbo.RequiredPermissionPlace",
                c => new
                    {
                        RequiredPermission_Id = c.Int(nullable: false),
                        Place_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequiredPermission_Id, t.Place_Id })
                .ForeignKey("dbo.RequiredPermission", t => t.RequiredPermission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Place", t => t.Place_Id, cascadeDelete: true)
                .Index(t => t.RequiredPermission_Id)
                .Index(t => t.Place_Id);
            
            DropColumn("dbo.RequiredPermission", "Place_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequiredPermission", "Place_Id", c => c.Int());
            DropForeignKey("dbo.RequiredPermissionPlace", "Place_Id", "dbo.Place");
            DropForeignKey("dbo.RequiredPermissionPlace", "RequiredPermission_Id", "dbo.RequiredPermission");
            DropIndex("dbo.RequiredPermissionPlace", new[] { "Place_Id" });
            DropIndex("dbo.RequiredPermissionPlace", new[] { "RequiredPermission_Id" });
            DropTable("dbo.RequiredPermissionPlace");
            CreateIndex("dbo.RequiredPermission", "Place_Id");
            AddForeignKey("dbo.RequiredPermission", "Place_Id", "dbo.Place", "Id");
        }
    }
}
