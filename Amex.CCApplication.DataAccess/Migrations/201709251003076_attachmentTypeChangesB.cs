namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class attachmentTypeChangesB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AMEXCCDB.Attachment",
                c => new
                {
                    AttachmentId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    FileName = c.String(nullable: false),
                    FileUrl = c.String(nullable: false),
                    AttachmentTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    CreditCardId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    CreatedBy = c.String(nullable: false),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(),
                })
                .PrimaryKey(t => t.AttachmentId)
                .ForeignKey("AMEXCCDB.AttachmentType", t => t.AttachmentTypeId, cascadeDelete: true)
                .ForeignKey("AMEXCCDB.CreditCard", t => t.CreditCardId, cascadeDelete: true)
                .Index(t => t.AttachmentTypeId)
                .Index(t => t.CreditCardId);

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
        }

        public override void Down()
        {
            DropForeignKey("AMEXCCDB.Attachment", "CreditCardId", "AMEXCCDB.CreditCard");
            DropForeignKey("AMEXCCDB.Attachment", "AttachmentTypeId", "AMEXCCDB.AttachmentType");
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCardId" });
            DropIndex("AMEXCCDB.Attachment", new[] { "AttachmentTypeId" });
            DropTable("AMEXCCDB.AttachmentType");
            DropTable("AMEXCCDB.Attachment");
        }
    }
}