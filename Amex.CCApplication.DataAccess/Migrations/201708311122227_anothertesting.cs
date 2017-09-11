namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothertesting : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.Nationality", "MyAge", c => c.Decimal(nullable: false, precision: 10, scale: 0));
        }
        
        public override void Down()
        {
            DropColumn("AMEXCCDB.Nationality", "MyAge");
        }
    }
}
