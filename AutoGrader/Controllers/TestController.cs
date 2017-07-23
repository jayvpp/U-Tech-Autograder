using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoGrader.Controllers
{

    public class Question
    {
        public string Type { get; set; }
        public string Statement { get; set; }
        //public double Score { get; set; }
    }

   public class MultipleChoiceQuestion : Question
    {
        public string[] PosibleAnswers { get; set; }
        public string[] CorrectAnswers { get; set; }
    }


    public class SingleChoiceQuestion : Question
    {
        public string[] PosibleAnswers { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class ShortAnswerQuestion : Question
    {
        public string Answer { get; set; }
    }


    public class ParagraphQuestion : Question
    {
    }



    public class Test
    {
        public int Id { get; set; }

        //public DateTime CreationTime;
        //public int MaxScore { get; set; }
        //public int PassingScore { get; set; }
        //public string Name { get; set; }

        public MultipleChoiceQuestion[] MultipleChoiceQuestions { get; set; }
        public SingleChoiceQuestion[] SingleChoiceQuestions { get; set; }
        public BooleanQuestion[] BooleanQuestions { get; set; }
        public ShortAnswerQuestion[] ShortAnswerQuestions { get; set; }
        public ParagraphQuestion[] ParagraphQuestions { get; set; }

        public int MultipleChoiceQuestionCount => MultipleChoiceQuestions != null ? MultipleChoiceQuestions.Count() : 0;
        public int SingleChoiceQuestionCount => SingleChoiceQuestions != null ? SingleChoiceQuestions.Count() : 0;
        public int BooleanQuestionCount => BooleanQuestions != null ? BooleanQuestions.Count() : 0;
        public int ShortAnswerQuestionCount => ShortAnswerQuestions != null ? ShortAnswerQuestions.Count() : 0;
        public int ParagraphQuestionCount => ParagraphQuestions != null ? ParagraphQuestions.Count() : 0;

        public int TotalQuestionCount => MultipleChoiceQuestionCount + 
                                         SingleChoiceQuestionCount +
                                         BooleanQuestionCount +
                                         ShortAnswerQuestionCount +
                                         ParagraphQuestionCount;
        
    }

    public class BooleanQuestion : Question
    {
        public bool answer { get; set; }
    }


    public class TestController : Controller
    {
        // GET: CreateTest
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="professor")]
        public ActionResult Create()
        {
            return View("Create");
        }



        [HttpPost]
        public string CreateMultipleChoiceQuestion(Test test)
        {
            return null;
        }

        [HttpPost]
        public string CreateSingleChoiceQuestion(Test test)
        {
            return null;
        }
    }
}