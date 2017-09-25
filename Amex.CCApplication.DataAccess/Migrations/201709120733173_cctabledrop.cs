namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class cctabledrop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            AlterColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId");
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId");
            DropColumn("AMEXCCDB.CreditCard", "FullName");
            DropColumn("AMEXCCDB.CreditCard", "DispalayName");
            DropColumn("AMEXCCDB.CreditCard", "Nic");
            DropColumn("AMEXCCDB.CreditCard", "Passport");
            DropColumn("AMEXCCDB.CreditCard", "Address");
            DropColumn("AMEXCCDB.CreditCard", "MobilePhone");
            DropColumn("AMEXCCDB.CreditCard", "HomePhone");
            DropColumn("AMEXCCDB.CreditCard", "OfficePhone");
            DropColumn("AMEXCCDB.CreditCard", "Email");
            DropColumn("AMEXCCDB.CreditCard", "Employer");
            DropColumn("AMEXCCDB.CreditCard", "Salary");
            DropColumn("AMEXCCDB.CreditCard", "JobTitle");
            DropColumn("AMEXCCDB.CreditCard", "CreditCardNumber");
            DropColumn("AMEXCCDB.CreditCard", "BillingDate");
            DropColumn("AMEXCCDB.CreditCard", "CardExpiryDate");
            DropColumn("AMEXCCDB.CreditCard", "Cvv");
            DropColumn("AMEXCCDB.CreditCard", "CardLimit");
            DropColumn("AMEXCCDB.CreditCard", "CashLimit");
            DropColumn("AMEXCCDB.CreditCard", "RequestedBy");
            DropColumn("AMEXCCDB.CreditCard", "Note");
        }

        public override void Down()
        {
            AddColumn("AMEXCCDB.CreditCard", "Note", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "RequestedBy", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "CashLimit", c => c.Decimal(precision: 18, scale: 3));
            AddColumn("AMEXCCDB.CreditCard", "CardLimit", c => c.Decimal(precision: 18, scale: 3));
            AddColumn("AMEXCCDB.CreditCard", "Cvv", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("AMEXCCDB.CreditCard", "CardExpiryDate", c => c.DateTime());
            AddColumn("AMEXCCDB.CreditCard", "BillingDate", c => c.DateTime());
            AddColumn("AMEXCCDB.CreditCard", "CreditCardNumber", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "JobTitle", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("AMEXCCDB.CreditCard", "Employer", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "Email", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "OfficePhone", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "HomePhone", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "MobilePhone", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "Address", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "Passport", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "Nic", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "DispalayName", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "FullName", c => c.String(nullable: false));
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            AlterColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId", cascadeDelete: true);
        }
    }
}