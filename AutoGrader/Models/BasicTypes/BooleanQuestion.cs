using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGrader.Models.BasicTypes
{ 
    public class BooleanQuestion : Question
    {
        public bool answer { get; set; }

        public override QuestionEvaluationResult Evaluate(QuestionResponses response)
        {
            var resp = response.Responses[0] == "True" ? true : false;
            var correct = resp == answer;
            return new QuestionEvaluationResult(Id, correct, Score, correct ? Score : 0);
        }
    }
}