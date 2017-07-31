using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoGrader.Models.BasicTypes
{
    public class QuestionEvaluationResult
    {
        public int Id { get; set; }
        public bool Correct { get; set; }
        public int MaxPoints { get; set; }
        public int Points { get; set; }
        public QuestionEvaluationResult(int id, bool correct, int maxPoints, int points)
        {
            Id = id;
            Correct = correct;
            MaxPoints = maxPoints;
            Points = points;
        }
    }
}