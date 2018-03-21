namespace MyBooksSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedYearOfPublication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "YearPublication", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "YearPublication");
        }
    }
}
