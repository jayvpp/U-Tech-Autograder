using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGrader.Models.BasicTypes
{

    public class ShortAnswerQuestion : Question
    {
        public string CorrectShortAnswer { get; set; }

        public override QuestionEvaluationResult Evaluate(QuestionResponses response)
        {
            var resp = response.Responses[0].ToLower();
            var correct = resp == CorrectShortAnswer;
            return new QuestionEvaluationResult(Id, correct, Score, correct ? Score : 0);
        }
    }
}