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
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100, storeType: "nvarchar"),
                        MiddleName = c.String(maxLength: 100, storeType: "nvarchar"),
                        LastName = c.String(maxLength: 100, storeType: "nvarchar"),
                        Notes = c.String(maxLength: 2500, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddr = c.String(maxLength: 100, storeType: "nvarchar"),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(maxLength: 20, storeType: "nvarchar"),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 10, storeType: "nvarchar"),
                        Type = c.Int(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Phones", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Groups", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Phones", new[] { "Contact_Id" });
            DropIndex("dbo.Groups", new[] { "Contact_Id" });
            DropIndex("dbo.Emails", new[] { "Contact_Id" });
            DropIndex("dbo.Addresses", new[] { "Contact_Id" });
            DropTable("dbo.Phones");
            DropTable("dbo.Groups");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
