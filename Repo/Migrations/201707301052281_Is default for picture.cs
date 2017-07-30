namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Isdefaultforpicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "IsDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "IsDefault");
        }
    }
}
