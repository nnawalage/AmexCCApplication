namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cardTypeFkAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId");
        }
    }
}
