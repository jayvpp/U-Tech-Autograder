using System;
using System.Collections.Generic;

namespace AutoGrader.Models.BasicTypes
{
    public interface ITestGraded
    {
        int MaxGrade { get; }
        int PassingGrade { get; }
        int GradeResult { get; }
        bool Pass { get; }
        DateTime SubmittedTimeSpan { get; }
        ICollection<QuestionEvaluationResult> QuestionResults { get;}
    }
}
