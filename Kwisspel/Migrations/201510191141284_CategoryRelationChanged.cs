namespace Kwisspel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryRelationChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Quiz_Id", "dbo.Quiz");
            DropIndex("dbo.Category", new[] { "Quiz_Id" });
            DropColumn("dbo.Category", "Quiz_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Quiz_Id", c => c.Int());
            CreateIndex("dbo.Category", "Quiz_Id");
            AddForeignKey("dbo.Category", "Quiz_Id", "dbo.Quiz", "Id");
        }
    }
}
