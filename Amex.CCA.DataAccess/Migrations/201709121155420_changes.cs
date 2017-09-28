namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("AMEXCCDB.CreditCard", "Email", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("AMEXCCDB.CreditCard", "Email", c => c.String());
        }
    }
}