namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class attachmentTypeChangesA : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            // DropForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType");
            // DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            // DropIndex("AMEXCCDB.Attachment", new[] { "Type_AttachmentTypeId" });
            DropTable("AMEXCCDB.AttachmentType");
            DropTable("AMEXCCDB.Attachment");
        }

        public override void Down()
        {
            CreateTable(
                "AMEXCCDB.Attachment",
                c => new
                {
                    AttachmentId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    FileName = c.String(nullable: false),
                    FileUrl = c.String(nullable: false),
                    CreatedBy = c.String(nullable: false),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(),
                    CreditCard_CreditCardId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    Type_AttachmentTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                })
                .PrimaryKey(t => t.AttachmentId);

            CreateTable(
                "AMEXCCDB.AttachmentType",
                c => new
                {
                    AttachmentTypeId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    Name = c.String(nullable: false),
                    IsActive = c.Decimal(nullable: false, precision: 1, scale: 0),
                    CreatedBy = c.String(nullable: false),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(),
                })
                .PrimaryKey(t => t.AttachmentTypeId);

            CreateIndex("AMEXCCDB.Attachment", "Type_AttachmentTypeId");
            CreateIndex("AMEXCCDB.Attachment", "CreditCard_CreditCardId");
            AddForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType", "AttachmentTypeId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard", "CreditCardId", cascadeDelete: true);
        }
    }
}