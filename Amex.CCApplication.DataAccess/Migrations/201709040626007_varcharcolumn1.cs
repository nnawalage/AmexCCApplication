namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class varcharcolumn1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("AMEXCCDB.Nationality", "Description");
        }
        
        public override void Down()
        {
            AddColumn("AMEXCCDB.Nationality", "Description", c => c.String(maxLength: 250));
        }
    }
}
