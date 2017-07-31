using AutoGrader.Models.BasicTypes;
using System;
using System.Collections.Generic;

namespace AutoGrader.Controllers
{
    public class Grader
    {
        AutoGradingDb db = new AutoGradingDb();

        public TestGradeResult Grade(TestResult testResult)
        {
            var totalScore = 0;

            var testTaken = db.Tests.Find(testResult.TestId);

            var allQuestion = testTaken.AllQuestions();
            var evaluation = new List<QuestionEvaluationResult>();

            foreach (var question in allQuestion)
            {
                var questionResponse = testResult.Find(question.Id);
                var evaluationResult = question.Evaluate(questionResponse);
                evaluation.Add(evaluationResult);
                totalScore += evaluationResult.Points;
            }

            return new TestGradeResult(totalScore, testTaken.MaxScore, testTaken.MaxScore, evaluation, DateTime.Now);

        }
    }
}