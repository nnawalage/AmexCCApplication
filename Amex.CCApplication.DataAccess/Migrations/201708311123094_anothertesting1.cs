namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothertesting1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("AMEXCCDB.Nationality", "MyAge");
        }
        
        public override void Down()
        {
            AddColumn("AMEXCCDB.Nationality", "MyAge", c => c.Decimal(nullable: false, precision: 10, scale: 0));
        }
    }
}
