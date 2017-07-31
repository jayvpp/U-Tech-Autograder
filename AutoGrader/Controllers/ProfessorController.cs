using AutoGrader.Models.BasicTypes;
using System.Linq;
using System.Web.Mvc;

namespace AutoGrader.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: CreateTest
        AutoGradingDb db = new AutoGradingDb();
        string ProfId => User.Identity.Name;


        [Authorize(Roles = "professor")]
        public ViewResult Index()
        {
            var tests = db.Tests.ToList()
                          .Where(t => t.ProfessorIdentification == ProfId);
            return View(tests);
        }

        [Authorize(Roles = "professor")]
        public ViewResult Edit(int id)
        {
            return null;
        }


        [Authorize(Roles = "professor")]
        public ViewResult Details(int id)
        {
            return null;
        }


        [Authorize(Roles = "professor")]
        public ActionResult Delete(int id)
        {
            var tests = db.Tests.Find(id);
            if (tests.ProfessorIdentification != ProfId)
                RedirectToAction("Index");

            db.Tests.Remove(tests);
       
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        [Authorize(Roles = "professor")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [Authorize(Roles = "professor")]
        public void Create(Test test)
        {
            test.ProfessorIdentification = User.Identity.Name;
            db.Tests.Add(test);
            db.SaveChanges();
            var tests = db.Tests.ToList();
        }


        [HttpPost]

        public void Grading(TestResult testResult)
        {
            Grader grader = new Grader();
            var grade = grader.Grade(testResult);

        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
                db.Dispose();
            base.Dispose(disposing);
        }

    }



 
 



 
}