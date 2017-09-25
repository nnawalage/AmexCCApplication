namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.Attachment", "FileUrl", c => c.String(nullable: false));
            DropColumn("AMEXCCDB.Attachment", "File");
        }
        
        public override void Down()
        {
            AddColumn("AMEXCCDB.Attachment", "File", c => c.Binary(nullable: false));
            DropColumn("AMEXCCDB.Attachment", "FileUrl");
        }
    }
}
