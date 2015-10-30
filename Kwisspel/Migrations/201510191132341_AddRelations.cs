namespace Kwisspel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Quiz_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.Quiz_Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Quiz_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Category", "Quiz_Id", "dbo.Quiz");
            DropForeignKey("dbo.Question", "Quiz_Id", "dbo.Quiz");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Question");
            DropIndex("dbo.Category", new[] { "Quiz_Id" });
            DropIndex("dbo.Question", new[] { "Category_Id" });
            DropIndex("dbo.Question", new[] { "Quiz_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropTable("dbo.Quiz");
            DropTable("dbo.Category");
            DropTable("dbo.Question");
            DropTable("dbo.Answers");
        }
    }
}
