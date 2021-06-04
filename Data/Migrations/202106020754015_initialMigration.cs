namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.Long(nullable: false),
                        Author = c.String(maxLength: 30),
                        BookName = c.String(maxLength: 55),
                        Genre = c.String(maxLength: 15),
                        DateORelease = c.DateTime(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookInCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.CartId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserInfoId = c.Int(nullable: false),
                        ISBN = c.Long(nullable: false),
                        Author = c.String(maxLength: 30),
                        BookName = c.String(maxLength: 55),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOAdding = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfoId, cascadeDelete: true)
                .Index(t => t.UserInfoId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 30),
                        Age = c.Byte(nullable: false),
                        PhoneNum = c.String(maxLength: 13),
                        Address = c.String(maxLength: 90),
                        DateORegistration = c.DateTime(nullable: false),
                        DebtCard = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookInCarts", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "UserInfoId", "dbo.UserInfoes");
            DropForeignKey("dbo.BookInCarts", "BookId", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "UserInfoId" });
            DropIndex("dbo.BookInCarts", new[] { "CartId" });
            DropIndex("dbo.BookInCarts", new[] { "BookId" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Carts");
            DropTable("dbo.BookInCarts");
            DropTable("dbo.Books");
        }
    }
}
