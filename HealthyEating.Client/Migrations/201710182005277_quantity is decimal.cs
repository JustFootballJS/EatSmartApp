namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantityisdecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quantities", "QuantityValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quantities", "QuantityValue", c => c.Int(nullable: false));
        }
    }
}
