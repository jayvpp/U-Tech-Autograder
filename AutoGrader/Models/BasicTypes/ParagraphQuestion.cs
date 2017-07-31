using System;

namespace AutoGrader.Models.BasicTypes
{
    public class ParagraphQuestion : Question
    {
        public override QuestionEvaluationResult Evaluate(QuestionResponses response)
        {
            return new QuestionEvaluationResult(Id, true, Score, Score);
        }
    }
}