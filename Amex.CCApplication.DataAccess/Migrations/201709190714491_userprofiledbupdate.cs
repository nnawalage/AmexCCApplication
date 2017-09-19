namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofiledbupdate : DbMigration
    {
        public override void Up()
        {
            DropTable("AMEXCCDB.UserProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "AMEXCCDB.UserProfiles",
                c => new
                    {
                        UserProfileId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ProfileName = c.String(nullable: false),
                        ProfileImage = c.Decimal(nullable: false, precision: 1, scale: 0),
                        IsActive = c.Decimal(nullable: false, precision: 1, scale: 0),
                        CreatedBy = c.String(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedTime = c.DateTime(),
                        DeletedBy = c.String(),
                        DeletedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserProfileId);
            
        }
    }
}
