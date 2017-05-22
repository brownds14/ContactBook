namespace ContactBook.DAL.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        Line2 = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100, storeType: "nvarchar"),
                        MiddleName = c.String(maxLength: 100, storeType: "nvarchar"),
                        LastName = c.String(maxLength: 100, storeType: "nvarchar"),
                        Notes = c.String(maxLength: 2500, storeType: "nvarchar"),
                        Addresses_Id = c.Int(),
                        Emails_Id = c.Int(),
                        Groups_Id = c.Int(),
                        Phones_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Addresses_Id, cascadeDelete: true)
                .ForeignKey("dbo.Emails", t => t.Emails_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Groups_Id, cascadeDelete: true)
                .ForeignKey("dbo.Phones", t => t.Phones_Id, cascadeDelete: true)
                .Index(t => t.Addresses_Id)
                .Index(t => t.Emails_Id)
                .Index(t => t.Groups_Id)
                .Index(t => t.Phones_Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddr = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 10, storeType: "nvarchar"),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Phones_Id", "dbo.Phones");
            DropForeignKey("dbo.Contacts", "Groups_Id", "dbo.Groups");
            DropForeignKey("dbo.Contacts", "Emails_Id", "dbo.Emails");
            DropForeignKey("dbo.Contacts", "Addresses_Id", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "Phones_Id" });
            DropIndex("dbo.Contacts", new[] { "Groups_Id" });
            DropIndex("dbo.Contacts", new[] { "Emails_Id" });
            DropIndex("dbo.Contacts", new[] { "Addresses_Id" });
            DropTable("dbo.Phones");
            DropTable("dbo.Groups");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
