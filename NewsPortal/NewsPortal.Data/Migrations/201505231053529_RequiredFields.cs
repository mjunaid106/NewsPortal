namespace NewsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Author_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Articles", "Author_Id");
            AddForeignKey("dbo.Articles", "Author_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Articles", "Author_Id", c => c.Int());
            AlterColumn("dbo.Articles", "Title", c => c.String());
            CreateIndex("dbo.Articles", "Author_Id");
            AddForeignKey("dbo.Articles", "Author_Id", "dbo.Users", "Id");
        }
    }
}
