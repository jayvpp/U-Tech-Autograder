using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoGrader.Controllers
{

   public class MultipleChoiceQuestion
    {
        public string type { get; set; }
        public string statement { get; set; }
        public string[] posibleAnswers { get; set; }
        public string[] correctAnswers { get; set; }
    }


    public class SingleChoiceQuestion
    {
        public string type { get; set; }
        public string statement { get; set; }
        public string[] posibleAnswers { get; set; }
        public string correctAnswer { get; set; }
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
        public string CreateMultipleChoiceQuestion(MultipleChoiceQuestion question)
        {
            return null;
        }

        [HttpPost]
        public string CreateSingleChoiceQuestion(SingleChoiceQuestion question)
        {
            return null;
        }
    }
}