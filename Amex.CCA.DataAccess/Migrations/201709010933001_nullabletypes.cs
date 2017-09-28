namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class nullabletypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("AMEXCCDB.AttachmentType", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.AttachmentType", "ModifiedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.AttachmentType", "DeletedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.Attachment", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.Attachment", "ModifiedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.Attachment", "DeletedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.CreditCard", "Note", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "ModifiedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.CreditCard", "DeletedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.CardStatus", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CardStatus", "ModifiedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.CardStatus", "DeletedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.CardType", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CardType", "ModifiedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.CardType", "DeletedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.Nationality", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.Nationality", "ModifiedTime", c => c.DateTime());
            AlterColumn("AMEXCCDB.Nationality", "DeletedTime", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("AMEXCCDB.Nationality", "DeletedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.Nationality", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.Nationality", "CreatedBy", c => c.String());
            AlterColumn("AMEXCCDB.CardType", "DeletedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.CardType", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.CardType", "CreatedBy", c => c.String());
            AlterColumn("AMEXCCDB.CardStatus", "DeletedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.CardStatus", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.CardStatus", "CreatedBy", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "DeletedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "CreatedBy", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "Note", c => c.String(maxLength: 200));
            AlterColumn("AMEXCCDB.Attachment", "DeletedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.Attachment", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.Attachment", "CreatedBy", c => c.String());
            AlterColumn("AMEXCCDB.AttachmentType", "DeletedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.AttachmentType", "ModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("AMEXCCDB.AttachmentType", "CreatedBy", c => c.String());
        }
    }
}