namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class nationalityFkAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId");
        }

        public override void Down()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            DropColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId");
        }
    }
}