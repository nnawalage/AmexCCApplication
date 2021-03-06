namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AMEXCCDB.UserProfile",
                c => new
                {
                    UserProfileId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    ProfileName = c.String(nullable: false),
                    ProfileImage = c.Decimal(nullable: false, precision: 1, scale: 0),
                    CreatedBy = c.String(nullable: false),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(),
                })
                .PrimaryKey(t => t.UserProfileId);
        }

        public override void Down()
        {
            DropTable("AMEXCCDB.UserProfile");
        }
    }
}