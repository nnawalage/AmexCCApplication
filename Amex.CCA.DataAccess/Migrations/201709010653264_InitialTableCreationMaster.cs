namespace Amex.CCA.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialTableCreationMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AMEXCCDB.CardStatus",
                c => new
                {
                    CardStatusId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    Name = c.String(),
                    IsActive = c.Decimal(nullable: false, precision: 1, scale: 0),
                    CreatedBy = c.String(),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(nullable: false),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CardStatusId);

            CreateTable(
                "AMEXCCDB.CardType",
                c => new
                {
                    CardTypeId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    Name = c.String(),
                    IsActive = c.Decimal(nullable: false, precision: 1, scale: 0),
                    CreatedBy = c.String(),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(nullable: false),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CardTypeId);

            CreateTable(
                "AMEXCCDB.Nationality",
                c => new
                {
                    NationalityId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                    Name = c.String(),
                    IsActive = c.Decimal(nullable: false, precision: 1, scale: 0),
                    CreatedBy = c.String(),
                    CreatedTime = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                    ModifiedTime = c.DateTime(nullable: false),
                    DeletedBy = c.String(),
                    DeletedTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.NationalityId);
        }

        public override void Down()
        {
            DropTable("AMEXCCDB.Nationality");
            DropTable("AMEXCCDB.CardType");
            DropTable("AMEXCCDB.CardStatus");
        }
    }
}