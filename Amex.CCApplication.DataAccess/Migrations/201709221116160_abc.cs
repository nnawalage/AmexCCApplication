namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            RenameColumn(table: "AMEXCCDB.Attachment", name: "Type_AttachmentTypeId", newName: "AttachmentTypeId");
            RenameIndex(table: "AMEXCCDB.Attachment", name: "IX_Type_AttachmentTypeId", newName: "IX_AttachmentTypeId");
            AddColumn("AMEXCCDB.Attachment", "FileUrl", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.Attachment", "CredictCardId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.Attachment", "CreditCard_CreditCardId", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.Attachment", "CreditCard_CreditCardId");
            AddForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard", "CreditCardId");
            DropColumn("AMEXCCDB.Attachment", "File");
        }
        
        public override void Down()
        {
            AddColumn("AMEXCCDB.Attachment", "File", c => c.Binary(nullable: false));
            DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            AlterColumn("AMEXCCDB.Attachment", "CreditCard_CreditCardId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            DropColumn("AMEXCCDB.Attachment", "CredictCardId");
            DropColumn("AMEXCCDB.Attachment", "FileUrl");
            RenameIndex(table: "AMEXCCDB.Attachment", name: "IX_AttachmentTypeId", newName: "IX_Type_AttachmentTypeId");
            RenameColumn(table: "AMEXCCDB.Attachment", name: "AttachmentTypeId", newName: "Type_AttachmentTypeId");
            CreateIndex("AMEXCCDB.Attachment", "CreditCard_CreditCardId");
            AddForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard", "CreditCardId", cascadeDelete: true);
        }
    }
}
