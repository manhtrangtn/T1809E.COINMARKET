namespace T1809E.COINMARKET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyPostModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "PostRank", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "PostRank");
            AddForeignKey("dbo.Posts", "PostRank", "dbo.Ranks", "Id", cascadeDelete: true);
            DropColumn("dbo.Posts", "Ranks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Ranks", c => c.String());
            DropForeignKey("dbo.Posts", "PostRank", "dbo.Ranks");
            DropIndex("dbo.Posts", new[] { "PostRank" });
            DropColumn("dbo.Posts", "PostRank");
            DropTable("dbo.Ranks");
        }
    }
}
