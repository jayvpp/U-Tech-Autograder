using AutoGrader.Models.BasicTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoGrader.Controllers
{
    [Authorize(Roles ="student")]
    public class StudentController : Controller
    {
        // GET: Student
        AutoGradingDb db = new AutoGradingDb();
        public ActionResult Index()
        {
            var tests = db.Tests.ToList();
            return View(tests);
        }


        public ActionResult Take(int id)
        {
            var test = db.Tests.Find(id);
            return View(test);
        }
    }
}