using System.Linq;

namespace AutoGrader.Models.BasicTypes
{
    public class Test
    {
        public int Id { get; set; }

        //public DateTime CreationTime;
        //public int MaxScore { get; set; }
        //public int PassingScore { get; set; }
        //public string Name { get; set; }

        public MultipleChoiceQuestion[] MultipleChoiceQuestions { get; set; }
        public SingleChoiceQuestion[] SingleChoiceQuestions { get; set; }
        public BooleanQuestion[] BooleanQuestions { get; set; }
        public ShortAnswerQuestion[] ShortAnswerQuestions { get; set; }
        public ParagraphQuestion[] ParagraphQuestions { get; set; }

        public int MultipleChoiceQuestionCount => MultipleChoiceQuestions != null ? MultipleChoiceQuestions.Count() : 0;
        public int SingleChoiceQuestionCount => SingleChoiceQuestions != null ? SingleChoiceQuestions.Count() : 0;
        public int BooleanQuestionCount => BooleanQuestions != null ? BooleanQuestions.Count() : 0;
        public int ShortAnswerQuestionCount => ShortAnswerQuestions != null ? ShortAnswerQuestions.Count() : 0;
        public int ParagraphQuestionCount => ParagraphQuestions != null ? ParagraphQuestions.Count() : 0;

        public int TotalQuestionCount => MultipleChoiceQuestionCount +
                                         SingleChoiceQuestionCount +
                                         BooleanQuestionCount +
                                         ShortAnswerQuestionCount +
                                         ParagraphQuestionCount;

    }
}