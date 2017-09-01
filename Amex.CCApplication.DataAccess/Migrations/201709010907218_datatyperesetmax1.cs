namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatyperesetmax1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("AMEXCCDB.CreditCard", "Note", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("AMEXCCDB.CreditCard", "Note", c => c.String());
        }
    }
}
