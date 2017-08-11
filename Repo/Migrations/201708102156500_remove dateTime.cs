namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Places", "AddDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "AddDate", c => c.DateTime(nullable: false));
        }
    }
}
