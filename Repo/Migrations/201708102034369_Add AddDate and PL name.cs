namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddDateandPLname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "AddDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "AddDate");
        }
    }
}
