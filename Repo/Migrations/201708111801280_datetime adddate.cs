namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeadddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "AddDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "AddDate");
        }
    }
}
