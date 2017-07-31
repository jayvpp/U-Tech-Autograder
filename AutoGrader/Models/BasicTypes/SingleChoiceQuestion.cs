using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGrader.Models.BasicTypes
{

    public class SingleChoiceQuestion : Question
    {
        public virtual ICollection<StringData> PosibleAnswers { get; set; }
        public string CorrectAnswer { get; set; }

        public override QuestionEvaluationResult Evaluate(QuestionResponses response)
        {
            var resp = response.Responses[0].ToLower();
            var correct = resp == CorrectAnswer;
            return new QuestionEvaluationResult(Id, correct, Score, correct ? Score : 0);
        }
    }


    public class StringData
    {
        public int Id { get; set; }
        public string Data { get; set; }

    }

}