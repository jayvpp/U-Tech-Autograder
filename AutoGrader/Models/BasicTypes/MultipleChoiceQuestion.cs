using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AutoGrader.Models.BasicTypes
{
    public class MultipleChoiceQuestion : Question
    {
        public virtual ICollection<StringData> PosibleAnswers { get; set; }
        public virtual ICollection<StringData> CorrectAnswers { get; set; }

        public override QuestionEvaluationResult Evaluate(QuestionResponses response)
        {
            //var correct = CorrectAnswers.All(ca => response.Responses.ToList().Contains(ca.Data));
            var correctAnswers = CorrectAnswers.Select(p => p.Data).ToList();

            if (correctAnswers.Count() != CorrectAnswers.Count())
            {
                return new QuestionEvaluationResult(Id, false, Score, 0);
            }

            foreach (var correct in response.Responses)
            {
                if (!correctAnswers.Contains(correct))
                    return new QuestionEvaluationResult(Id, false, Score, 0);
            }

            return new QuestionEvaluationResult(Id, true, Score, Score);
        }
    }

}