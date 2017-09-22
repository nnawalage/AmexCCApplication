namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class cctabledrop1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            RenameColumn(table: "AMEXCCDB.CreditCard", name: "CardStatus_CardStatusId", newName: "CardStatusId");
            RenameColumn(table: "AMEXCCDB.CreditCard", name: "CardType_CardTypeId", newName: "CardTypeId");
            RenameColumn(table: "AMEXCCDB.CreditCard", name: "Nationality_NationalityId", newName: "NationalityId");
            AddColumn("AMEXCCDB.CreditCard", "FullName", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "DisplayName", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "Nic", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "Passport", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "Address", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "MobilePhone", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "HomePhone", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "OfficePhone", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "Email", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "Employer", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("AMEXCCDB.CreditCard", "JobTitle", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "CreditCardNumber", c => c.String());
            AddColumn("AMEXCCDB.CreditCard", "BillingDate", c => c.DateTime());
            AddColumn("AMEXCCDB.CreditCard", "CardExpiryDate", c => c.DateTime());
            AddColumn("AMEXCCDB.CreditCard", "Cvv", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("AMEXCCDB.CreditCard", "CardLimit", c => c.Decimal(precision: 18, scale: 3));
            AddColumn("AMEXCCDB.CreditCard", "CashLimit", c => c.Decimal(precision: 18, scale: 3));
            AddColumn("AMEXCCDB.CreditCard", "RequestedBy", c => c.String(nullable: false));
            AddColumn("AMEXCCDB.CreditCard", "Note", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "CardStatusId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardTypeId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "NationalityId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.CreditCard", "CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "NationalityId");
            CreateIndex("AMEXCCDB.CreditCard", "CardStatusId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.CreditCard", "CardTypeId", "AMEXCCDB.CardType", "CardTypeId", cascadeDelete: true);
            AddForeignKey("AMEXCCDB.CreditCard", "NationalityId", "AMEXCCDB.Nationality", "NationalityId", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "NationalityId", "AMEXCCDB.Nationality");
            DropForeignKey("AMEXCCDB.CreditCard", "CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatusId", "AMEXCCDB.CardStatus");
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatusId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "NationalityId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardTypeId" });
            AlterColumn("AMEXCCDB.CreditCard", "NationalityId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardTypeId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardStatusId", c => c.Decimal(precision: 10, scale: 0));
            DropColumn("AMEXCCDB.CreditCard", "Note");
            DropColumn("AMEXCCDB.CreditCard", "RequestedBy");
            DropColumn("AMEXCCDB.CreditCard", "CashLimit");
            DropColumn("AMEXCCDB.CreditCard", "CardLimit");
            DropColumn("AMEXCCDB.CreditCard", "Cvv");
            DropColumn("AMEXCCDB.CreditCard", "CardExpiryDate");
            DropColumn("AMEXCCDB.CreditCard", "BillingDate");
            DropColumn("AMEXCCDB.CreditCard", "CreditCardNumber");
            DropColumn("AMEXCCDB.CreditCard", "JobTitle");
            DropColumn("AMEXCCDB.CreditCard", "Salary");
            DropColumn("AMEXCCDB.CreditCard", "Employer");
            DropColumn("AMEXCCDB.CreditCard", "Email");
            DropColumn("AMEXCCDB.CreditCard", "OfficePhone");
            DropColumn("AMEXCCDB.CreditCard", "HomePhone");
            DropColumn("AMEXCCDB.CreditCard", "MobilePhone");
            DropColumn("AMEXCCDB.CreditCard", "Address");
            DropColumn("AMEXCCDB.CreditCard", "Passport");
            DropColumn("AMEXCCDB.CreditCard", "Nic");
            DropColumn("AMEXCCDB.CreditCard", "DisplayName");
            DropColumn("AMEXCCDB.CreditCard", "FullName");
            RenameColumn(table: "AMEXCCDB.CreditCard", name: "NationalityId", newName: "Nationality_NationalityId");
            RenameColumn(table: "AMEXCCDB.CreditCard", name: "CardTypeId", newName: "CardType_CardTypeId");
            RenameColumn(table: "AMEXCCDB.CreditCard", name: "CardStatusId", newName: "CardStatus_CardStatusId");
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId");
        }
    }
}