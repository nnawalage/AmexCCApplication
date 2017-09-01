namespace Amex.CCA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypereset1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType");
            DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            DropIndex("AMEXCCDB.Attachment", new[] { "Type_AttachmentTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            DropPrimaryKey("AMEXCCDB.AttachmentType");
            DropPrimaryKey("AMEXCCDB.Attachment");
            DropPrimaryKey("AMEXCCDB.CreditCard");
            DropPrimaryKey("AMEXCCDB.CardStatus");
            DropPrimaryKey("AMEXCCDB.CardType");
            DropPrimaryKey("AMEXCCDB.Nationality");
            AlterColumn("AMEXCCDB.AttachmentType", "AttachmentTypeId", c => c.Decimal(nullable: false, precision: 10, scale: 0, identity: true));
            AlterColumn("AMEXCCDB.Attachment", "AttachmentId", c => c.Decimal(nullable: false, precision: 10, scale: 0, identity: true));
            AlterColumn("AMEXCCDB.Attachment", "CreditCard_CreditCardId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.Attachment", "Type_AttachmentTypeId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CreditCardId", c => c.Decimal(nullable: false, precision: 10, scale: 0, identity: true));
            AlterColumn("AMEXCCDB.CreditCard", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("AMEXCCDB.CreditCard", "Cvv", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardLimit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("AMEXCCDB.CreditCard", "CashLimit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("AMEXCCDB.CardStatus", "CardStatusId", c => c.Decimal(nullable: false, precision: 10, scale: 0, identity: true));
            AlterColumn("AMEXCCDB.CardType", "CardTypeId", c => c.Decimal(nullable: false, precision: 10, scale: 0, identity: true));
            AlterColumn("AMEXCCDB.Nationality", "NationalityId", c => c.Decimal(nullable: false, precision: 10, scale: 0, identity: true));
            AddPrimaryKey("AMEXCCDB.AttachmentType", "AttachmentTypeId");
            AddPrimaryKey("AMEXCCDB.Attachment", "AttachmentId");
            AddPrimaryKey("AMEXCCDB.CreditCard", "CreditCardId");
            AddPrimaryKey("AMEXCCDB.CardStatus", "CardStatusId");
            AddPrimaryKey("AMEXCCDB.CardType", "CardTypeId");
            AddPrimaryKey("AMEXCCDB.Nationality", "NationalityId");
            CreateIndex("AMEXCCDB.Attachment", "CreditCard_CreditCardId");
            CreateIndex("AMEXCCDB.Attachment", "Type_AttachmentTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            AddForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType", "AttachmentTypeId");
            AddForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard", "CreditCardId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId");
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId");
        }
        
        public override void Down()
        {
            DropForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality");
            DropForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType");
            DropForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus");
            DropForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard");
            DropForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType");
            DropIndex("AMEXCCDB.CreditCard", new[] { "Nationality_NationalityId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardType_CardTypeId" });
            DropIndex("AMEXCCDB.CreditCard", new[] { "CardStatus_CardStatusId" });
            DropIndex("AMEXCCDB.Attachment", new[] { "Type_AttachmentTypeId" });
            DropIndex("AMEXCCDB.Attachment", new[] { "CreditCard_CreditCardId" });
            DropPrimaryKey("AMEXCCDB.Nationality");
            DropPrimaryKey("AMEXCCDB.CardType");
            DropPrimaryKey("AMEXCCDB.CardStatus");
            DropPrimaryKey("AMEXCCDB.CreditCard");
            DropPrimaryKey("AMEXCCDB.Attachment");
            DropPrimaryKey("AMEXCCDB.AttachmentType");
            AlterColumn("AMEXCCDB.Nationality", "NationalityId", c => c.Int(nullable: false, identity: true, storeType: "int"));
            AlterColumn("AMEXCCDB.CardType", "CardTypeId", c => c.Int(nullable: false, identity: true, storeType: "int"));
            AlterColumn("AMEXCCDB.CardStatus", "CardStatusId", c => c.Int(nullable: false, identity: true, storeType: "int"));
            AlterColumn("AMEXCCDB.CreditCard", "Nationality_NationalityId", c => c.Int(storeType: "int"));
            AlterColumn("AMEXCCDB.CreditCard", "CardType_CardTypeId", c => c.Int(storeType: "int"));
            AlterColumn("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", c => c.Int(storeType: "int"));
            AlterColumn("AMEXCCDB.CreditCard", "CashLimit", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("AMEXCCDB.CreditCard", "CardLimit", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("AMEXCCDB.CreditCard", "Cvv", c => c.Int(nullable: false, storeType: "int"));
            AlterColumn("AMEXCCDB.CreditCard", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("AMEXCCDB.CreditCard", "CreditCardId", c => c.Int(nullable: false, identity: true, storeType: "int"));
            AlterColumn("AMEXCCDB.Attachment", "Type_AttachmentTypeId", c => c.Int(storeType: "int"));
            AlterColumn("AMEXCCDB.Attachment", "CreditCard_CreditCardId", c => c.Int(storeType: "int"));
            AlterColumn("AMEXCCDB.Attachment", "AttachmentId", c => c.Int(nullable: false, identity: true, storeType: "int"));
            AlterColumn("AMEXCCDB.AttachmentType", "AttachmentTypeId", c => c.Int(nullable: false, identity: true, storeType: "int"));
            AddPrimaryKey("AMEXCCDB.Nationality", "NationalityId");
            AddPrimaryKey("AMEXCCDB.CardType", "CardTypeId");
            AddPrimaryKey("AMEXCCDB.CardStatus", "CardStatusId");
            AddPrimaryKey("AMEXCCDB.CreditCard", "CreditCardId");
            AddPrimaryKey("AMEXCCDB.Attachment", "AttachmentId");
            AddPrimaryKey("AMEXCCDB.AttachmentType", "AttachmentTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "Nationality_NationalityId");
            CreateIndex("AMEXCCDB.CreditCard", "CardType_CardTypeId");
            CreateIndex("AMEXCCDB.CreditCard", "CardStatus_CardStatusId");
            CreateIndex("AMEXCCDB.Attachment", "Type_AttachmentTypeId");
            CreateIndex("AMEXCCDB.Attachment", "CreditCard_CreditCardId");
            AddForeignKey("AMEXCCDB.CreditCard", "Nationality_NationalityId", "AMEXCCDB.Nationality", "NationalityId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardType_CardTypeId", "AMEXCCDB.CardType", "CardTypeId");
            AddForeignKey("AMEXCCDB.CreditCard", "CardStatus_CardStatusId", "AMEXCCDB.CardStatus", "CardStatusId");
            AddForeignKey("AMEXCCDB.Attachment", "CreditCard_CreditCardId", "AMEXCCDB.CreditCard", "CreditCardId");
            AddForeignKey("AMEXCCDB.Attachment", "Type_AttachmentTypeId", "AMEXCCDB.AttachmentType", "AttachmentTypeId");
        }
    }
}
