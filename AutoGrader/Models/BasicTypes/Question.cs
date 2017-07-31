using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGrader.Models.BasicTypes
{
    public abstract class Question
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Statement { get; set; }
        public int Score { get; set; }
        [JsonIgnoreAttribute]
        public Test Test { get; set; }

        public abstract QuestionEvaluationResult Evaluate(QuestionResponses response);
    }
}