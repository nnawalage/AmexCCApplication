namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreditCardTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AMEXCCDB.CreditCard",
                c => new
                {
                    CreditCardId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    FullName = c.String(),
                    DispalayName = c.String(),
                    Nic = c.String(),
                    Passport = c.String(),
                    Address = c.String(),
                    MobilePhone = c.String(),
                    HomePhone = c.String(),
                    OfficePhone = c.String(),
                    Email = c.String(),
                    Employer = c.String(),
                    Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CreditCardNumber = c.String(),
                    BillingDate = c.DateTime(nullable: false),
                    CardExpiryDate = c.DateTime(nullable: false),
                    Cvv = c.Decimal(nullable: false, precision: 10, scale: 0),
                    CardLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CashLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    RequestedBy = c.String(),
                    Note = c.String(),
                    CreatedBy = c.String(),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(nullable: false),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CreditCardId);
        }

        public override void Down()
        {
            DropTable("AMEXCCDB.CreditCard");
        }
    }
}