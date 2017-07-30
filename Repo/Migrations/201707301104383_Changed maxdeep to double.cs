namespace Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedmaxdeeptodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "MaxDeep", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "MaxDeep", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
