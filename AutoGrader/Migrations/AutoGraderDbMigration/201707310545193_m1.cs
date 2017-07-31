namespace AutoGrader.Migrations.AutoGraderDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StringDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        MultipleChoiceQuestion_Id = c.Int(),
                        MultipleChoiceQuestion_Id1 = c.Int(),
                        SingleChoiceQuestion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.MultipleChoiceQuestion_Id)
                .ForeignKey("dbo.Questions", t => t.MultipleChoiceQuestion_Id1)
                .ForeignKey("dbo.Questions", t => t.SingleChoiceQuestion_Id)
                .Index(t => t.MultipleChoiceQuestion_Id)
                .Index(t => t.MultipleChoiceQuestion_Id1)
                .Index(t => t.SingleChoiceQuestion_Id);
            
            CreateTable(
                "dbo.QuestionEvaluationResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Correct = c.Boolean(nullable: false),
                        MaxPoints = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        TestGradeResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestGradeResults", t => t.TestGradeResult_Id)
                .Index(t => t.TestGradeResult_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Statement = c.String(),
                        Score = c.Int(nullable: false),
                        answer = c.Boolean(),
                        CorrectShortAnswer = c.String(),
                        CorrectAnswer = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Test_Id = c.Int(),
                        Test_Id1 = c.Int(),
                        Test_Id2 = c.Int(),
                        Test_Id3 = c.Int(),
                        Test_Id4 = c.Int(),
                        Test_Id5 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id1)
                .ForeignKey("dbo.Tests", t => t.Test_Id2)
                .ForeignKey("dbo.Tests", t => t.Test_Id3)
                .ForeignKey("dbo.Tests", t => t.Test_Id4)
                .ForeignKey("dbo.Tests", t => t.Test_Id5)
                .Index(t => t.Test_Id)
                .Index(t => t.Test_Id1)
                .Index(t => t.Test_Id2)
                .Index(t => t.Test_Id3)
                .Index(t => t.Test_Id4)
                .Index(t => t.Test_Id5);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfessorIdentification = c.String(),
                        Name = c.String(),
                        MaxScore = c.Int(nullable: false),
                        PassingScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestGradeResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionEvaluationResults", "TestGradeResult_Id", "dbo.TestGradeResults");
            DropForeignKey("dbo.Questions", "Test_Id5", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Test_Id4", "dbo.Tests");
            DropForeignKey("dbo.StringDatas", "SingleChoiceQuestion_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Test_Id3", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Test_Id2", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Test_Id1", "dbo.Tests");
            DropForeignKey("dbo.StringDatas", "MultipleChoiceQuestion_Id1", "dbo.Questions");
            DropForeignKey("dbo.StringDatas", "MultipleChoiceQuestion_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            DropIndex("dbo.Questions", new[] { "Test_Id5" });
            DropIndex("dbo.Questions", new[] { "Test_Id4" });
            DropIndex("dbo.Questions", new[] { "Test_Id3" });
            DropIndex("dbo.Questions", new[] { "Test_Id2" });
            DropIndex("dbo.Questions", new[] { "Test_Id1" });
            DropIndex("dbo.Questions", new[] { "Test_Id" });
            DropIndex("dbo.QuestionEvaluationResults", new[] { "TestGradeResult_Id" });
            DropIndex("dbo.StringDatas", new[] { "SingleChoiceQuestion_Id" });
            DropIndex("dbo.StringDatas", new[] { "MultipleChoiceQuestion_Id1" });
            DropIndex("dbo.StringDatas", new[] { "MultipleChoiceQuestion_Id" });
            DropTable("dbo.TestGradeResults");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionEvaluationResults");
            DropTable("dbo.StringDatas");
        }
    }
}
