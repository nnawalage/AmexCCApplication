namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableTypesAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("AMEXCCDB.CreditCard", "OfficePhone", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "Email", c => c.String());
            AlterColumn("AMEXCCDB.CreditCard", "Cvv", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardLimit", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("AMEXCCDB.CreditCard", "CashLimit", c => c.Decimal(precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("AMEXCCDB.CreditCard", "CashLimit", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("AMEXCCDB.CreditCard", "CardLimit", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("AMEXCCDB.CreditCard", "Cvv", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "Email", c => c.String(nullable: false));
            AlterColumn("AMEXCCDB.CreditCard", "OfficePhone", c => c.String(nullable: false));
        }
    }
}
