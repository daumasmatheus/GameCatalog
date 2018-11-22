namespace GameCatalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        DeveloperId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .ForeignKey("dbo.GamePublishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.DeveloperId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.GamePublishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PublisherId", "dbo.GamePublishers");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "PublisherId" });
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropTable("dbo.GamePublishers");
            DropTable("dbo.Games");
            DropTable("dbo.Developers");
        }
    }
}
