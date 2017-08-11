namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PLver2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "AddDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "AddDate", c => c.Int(nullable: false));
        }
    }
}
