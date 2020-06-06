namespace T1809E.COINMARKET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addThumbnailForPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Thumbnail");
        }
    }
}
