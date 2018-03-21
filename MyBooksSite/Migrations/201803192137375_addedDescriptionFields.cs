namespace MyBooksSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDescriptionFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Description", c => c.String());
            AddColumn("dbo.Books", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
            DropColumn("dbo.Authors", "Description");
        }
    }
}
