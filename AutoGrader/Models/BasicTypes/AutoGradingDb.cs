using System.Data.Entity;

namespace AutoGrader.Models.BasicTypes
{
    public class AutoGradingDb : DbContext
    {
        public virtual DbSet<Test> Tests { get; set; }
        //public virtual DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        //public virtual DbSet<SingleChoiceQuestion> SingleChoiceQuestion { get; set; }
        //public virtual DbSet<BooleanQuestion> BooleanQuestion { get; set; }
        //public virtual DbSet<ShortAnswerQuestion> ShortAnswerQuestion { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<StringData> PosibleAnswers { get; set; }
        public virtual DbSet<TestGradeResult> TestGraded { get; set; }
        public virtual DbSet<QuestionEvaluationResult> QuestionResults { get; set; }

        public Test FindTestById(int id)
        {
            var test = Tests.Find(id);
            return test;
        }

     
    }
}