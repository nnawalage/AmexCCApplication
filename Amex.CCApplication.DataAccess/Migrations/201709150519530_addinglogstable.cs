namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinglogstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AMEXCCDB.Log",
                c => new
                    {
                        LogId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Action = c.String(),
                        Comment = c.String(),
                        CreditCardId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreatedBy = c.String(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedTime = c.DateTime(),
                        DeletedBy = c.String(),
                        DeletedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("AMEXCCDB.CreditCard", t => t.CreditCardId, cascadeDelete: true)
                .Index(t => t.CreditCardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("AMEXCCDB.Log", "CreditCardId", "AMEXCCDB.CreditCard");
            DropIndex("AMEXCCDB.Log", new[] { "CreditCardId" });
            DropTable("AMEXCCDB.Log");
        }
    }
}
