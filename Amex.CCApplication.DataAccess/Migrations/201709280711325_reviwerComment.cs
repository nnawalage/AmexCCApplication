namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviwerComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.CreditCard", "ReviewerComment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("AMEXCCDB.CreditCard", "ReviewerComment");
        }
    }
}
