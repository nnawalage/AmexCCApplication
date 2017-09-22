namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class requiredcc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            AlterColumn("AMEXCCDB.CreditCard", "FullName", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "DispalayName", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "Nic", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "Address", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "MobilePhone", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "HomePhone", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "OfficePhone", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "Email", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "Employer", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "RequestedBy", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            AlterColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "RequestedBy", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "Employer", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "Email", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "OfficePhone", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "HomePhone", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "MobilePhone", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "Address", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "Nic", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "DispalayName", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "FullName", c => c.String());
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId");
        }
    }
}