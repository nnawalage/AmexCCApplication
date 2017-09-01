namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cardStatusFkAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            DropColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
        }
    }
}
