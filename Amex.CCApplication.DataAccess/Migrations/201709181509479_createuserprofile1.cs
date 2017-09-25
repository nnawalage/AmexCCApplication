namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class createuserprofile1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("AMEXCCDB.UserProfile", "IsActive", c => c.Decimal(nullable: false, precision: 1, scale: 0));
        }

        public override void Down()
        {
            DropColumn("AMEXCCDB.UserProfile", "IsActive");
        }
    }
}