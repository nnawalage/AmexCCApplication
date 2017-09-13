namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requestedByRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("AMEXCCDB.CreditCard", "RequestedBy");
        }
        
        public override void Down()
        {
            AddColumn("AMEXCCDB.CreditCard", "RequestedBy", c => c.String(nullable: false));
        }
    }
}
