namespace NewsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        ArticleType = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                        Publisher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Publisher_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Publisher_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Articles", new[] { "Publisher_Id" });
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Authors");
            DropTable("dbo.Articles");
        }
    }
}
