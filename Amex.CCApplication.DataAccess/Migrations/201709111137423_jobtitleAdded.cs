namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobtitleAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.CreditCard", "JobTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("AMEXCCDB.CreditCard", "JobTitle");
        }
    }
}
