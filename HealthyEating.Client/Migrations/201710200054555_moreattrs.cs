namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreattrs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredients", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredients", "Name", c => c.String());
        }
    }
}
