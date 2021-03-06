namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class changingbacktoprimarykey : DbMigration
    {
        public override void Up()
        {
            DropTable("AMEXCCDB.Nationality");
        }

        public override void Down()
        {
            CreateTable(
                "AMEXCCDB.Nationality",
                c => new
                {
                    NationalityId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    Name = c.String(),
                    Status = c.Decimal(nullable: false, precision: 1, scale: 0),
                    CreatedBy = c.String(),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(nullable: false),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.NationalityId);
        }
    }
}