namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredccforce : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType");
            DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            DropIndex("AMEXCCDB.Attachment", new[] { "Type_AttachmentTypeId" });
            AlterColumn("AMEXCCDB.AttachmentType", "Name", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.Attachment", "FileName", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.Attachment", "File", c => c.Binary(nullable: false));
            AlterColumn("AMEXCCDB.Attachment", "CreditCard_CreditCardId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.Attachment", "Type_AttachmentTypeId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "BillingDate", c => c.DateTime());
            AlterColumn("AMEXCCDB.CreditCard", "CardExpiryDate", c => c.DateTime());
            AlterColumn("AMEXCCDB.CardStatus", "Name", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CardType", "Name", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.Nationality", "Name", c => c.String(nullable: false));
            CreateIndex("AMEXCCDB.Attachment", "CreditCard_CreditCardId");
            CreateIndex("AMEXCCDB.Attachment", "Type_AttachmentTypeId");
            AddForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType", "AttachmentTypeId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard", "CreditCardId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            DropForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType");
            DropIndex("AMEXCCDB.Attachment", new[] { "Type_AttachmentTypeId" });
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            AlterColumn("AMEXCCDB.Nationality", "Name", c => c.String());
            AlterColumn("AMEXCCDB.CardType", "Name", c => c.String());
            AlterColumn("AMEXCCDB.CardStatus", "Name", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "CardExpiryDate", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "BillingDate", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.Attachment", "Type_AttachmentTypeId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.Attachment", "CreditCard_CreditCardId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.Attachment", "File", c => c.Binary());
            AlterColumn("AMEXCCDB.Attachment", "FileName", c => c.String());
            AlterColumn("AMEXCCDB.AttachmentType", "Name", c => c.String());
            CreateIndex("AMEXCCDB.Attachment", "Type_AttachmentTypeId");
            CreateIndex("AMEXCCDB.Attachment", "CreditCard_CreditCardId");
            AddForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard", "CreditCardId");
            AddForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType", "AttachmentTypeId");
        }
    }
}
