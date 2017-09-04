namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class varcharcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.Nationality", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("AMEXCCDB.Nationality", "Description");
        }
    }
}
