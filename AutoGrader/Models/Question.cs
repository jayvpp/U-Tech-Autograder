using System.Collections.Generic;

namespace AutoGrader.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Statement { get; set; }
        public int Score { get; set; }
    }


    public class SingleChoiceQuestion : Question
    {
        public IEnumerable<string> PossibleAnswers { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class MultipleChoiceQuestion : Question
    {
        public IEnumerable<string> PossibleAnswers { get; set; }
        public IEnumerable<string> CorrectAnswer { get; set; }
    }


    public class TrueFalseQuestion : Question
    {
        public bool Answer { get; set; }
    }

}