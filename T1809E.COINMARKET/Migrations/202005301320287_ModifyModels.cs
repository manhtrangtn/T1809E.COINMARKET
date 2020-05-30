namespace T1809E.COINMARKET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RankToken = c.String(),
                        Total = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PostedUser = c.String(maxLength: 128),
                        Content = c.String(),
                        Ranks = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PostedUser)
                .Index(t => t.PostedUser);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostedUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "PostedUser" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "DeletedAt");
            DropColumn("dbo.AspNetUsers", "UpdatedAt");
            DropColumn("dbo.AspNetUsers", "CreatedAt");
            DropColumn("dbo.AspNetUsers", "BirthDay");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Posts");
            DropTable("dbo.Orders");
        }
    }
}
