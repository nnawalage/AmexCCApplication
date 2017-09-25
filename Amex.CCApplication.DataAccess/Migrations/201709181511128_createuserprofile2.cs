namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class createuserprofile2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "AMEXCCDB.UserProfile", newName: "UserProfiles");
        }

        public override void Down()
        {
            RenameTable(name: "AMEXCCDB.UserProfiles", newName: "UserProfile");
        }
    }
}