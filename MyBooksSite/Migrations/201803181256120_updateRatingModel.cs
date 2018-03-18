namespace MyBooksSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRatingModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "BookId", "dbo.Books");
            DropIndex("dbo.Ratings", new[] { "BookId" });
            CreateTable(
                "dbo.BookRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stars = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.BookRatings", "BookId", "dbo.Books");
            DropIndex("dbo.BookRatings", new[] { "BookId" });
            DropTable("dbo.BookRatings");
            CreateIndex("dbo.Ratings", "BookId");
            AddForeignKey("dbo.Ratings", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
