using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AutoGrader.Models.BasicTypes
{
    public class Test
    {
        public int Id { get; set; }
        [Display(Name = "Professor")]
        public string ProfessorIdentification { get; set; }
        [Display(Name = "Test Name")]
        public string Name { get; set; }
        [Display(Name = "Score")]
        public int MaxScore { get; set; }
        [Display(Name = "Passing Score")]
        public int PassingScore { get; set; }


        public virtual ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }

        public virtual ICollection<SingleChoiceQuestion> SingleChoiceQuestions { get; set; }

        public virtual ICollection<BooleanQuestion> BooleanQuestions { get; set; }

        public virtual ICollection<ShortAnswerQuestion> ShortAnswerQuestions { get; set; }

        public virtual ICollection<ParagraphQuestion> ParagraphQuestions { get; set; }

        public int MultipleChoiceQuestionCount => MultipleChoiceQuestions != null ? MultipleChoiceQuestions.Count() : 0;

        public int SingleChoiceQuestionCount => SingleChoiceQuestions != null ? SingleChoiceQuestions.Count() : 0;

        public int BooleanQuestionCount => BooleanQuestions != null ? BooleanQuestions.Count() : 0;

        public int ShortAnswerQuestionCount => ShortAnswerQuestions != null ? ShortAnswerQuestions.Count() : 0;

        public int ParagraphQuestionCount => ParagraphQuestions != null ? ParagraphQuestions.Count() : 0;

        public int TotalQuestionCount => MultipleChoiceQuestionCount +
                                         SingleChoiceQuestionCount   +
                                         BooleanQuestionCount        +
                                         ShortAnswerQuestionCount    +
                                         ParagraphQuestionCount;

        public virtual IEnumerable<Question> AllQuestions()
        {
            var list = new List<Question>();
            if (MultipleChoiceQuestions?.Count > 0)
                list = Enumerable.Concat(list, MultipleChoiceQuestions).ToList();
            
            if (SingleChoiceQuestions?.Count > 0)
                list = Enumerable.Concat(list, SingleChoiceQuestions).ToList();

            if (ShortAnswerQuestions?.Count > 0)
                list = Enumerable.Concat(list, ShortAnswerQuestions).ToList();

            if (BooleanQuestions?.Count > 0)
                list =  Enumerable.Concat(list, BooleanQuestions).ToList();

            return list;
        }
    }
}