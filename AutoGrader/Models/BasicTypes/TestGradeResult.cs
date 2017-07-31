using System;
using System.Collections.Generic;

namespace AutoGrader.Models.BasicTypes
{
    public class TestGradeResult : ITestGraded
    {
        public int Id { get; set; }
        public int GradeResult { get; }
        public int MaxGrade { get; }
        public bool Pass { get; }
        public int PassingGrade { get; }
        public DateTime SubmittedTimeSpan { get; }
        public ICollection<QuestionEvaluationResult> QuestionResults { get; set; }
        
        public TestGradeResult(int gradeResult, int maxGrade, int passingGrade, ICollection<QuestionEvaluationResult> questionResults, DateTime submittedTimeSpan)
        {
            GradeResult = gradeResult;
            MaxGrade = maxGrade;
            PassingGrade = passingGrade;
            Pass = gradeResult >= passingGrade ? true : false;
            QuestionResults = questionResults;
            SubmittedTimeSpan = submittedTimeSpan;
        }
    }
}