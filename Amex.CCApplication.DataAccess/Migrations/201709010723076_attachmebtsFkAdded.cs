namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attachmebtsFkAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AMEXCCDB.Attachment",
                c => new
                    {
                        AttachmentId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FileName = c.String(),
                        File = c.Binary(),
                        CreatedBy = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedTime = c.DateTime(nullable: false),
                        DeletedBy = c.String(),
                        DeletedTime = c.DateTime(nullable: false),
                        CreditCard_CreditCardId = c.Decimal(precision: 10, scale: 0),
                        Type_AttachmentTypeId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.AttachmentId)
                .ForeignKey("AMEXCCDB.CreditCard", t => t.CreditCard_CreditCardId)
                .ForeignKey("AMEXCCDB.AttachmentType", t => t.Type_AttachmentTypeId)
                .Index(t => t.CreditCard_CreditCardId)
                .Index(t => t.Type_AttachmentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType");
            DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            DropIndex("AMEXCCDB.Attachment", new[] { "Type_AttachmentTypeId" });
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            DropTable("AMEXCCDB.Attachment");
        }
    }
}
