namespace MyBooksSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedSeparateRatingsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookRatings", "BookId", "dbo.Books");
            DropIndex("dbo.BookRatings", new[] { "BookId" });
            AddColumn("dbo.Books", "SumRatings", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "NumberOfRatings", c => c.Int(nullable: false));
            DropTable("dbo.BookRatings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Books", "NumberOfRatings");
            DropColumn("dbo.Books", "SumRatings");
            CreateIndex("dbo.BookRatings", "BookId");
            AddForeignKey("dbo.BookRatings", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
