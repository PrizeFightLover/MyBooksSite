namespace MyBooksSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewsBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberOfViews", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberOfViews");
        }
    }
}
