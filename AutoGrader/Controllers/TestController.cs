using AutoGrader.Models.BasicTypes;
using System.Web.Mvc;

namespace AutoGrader.Controllers
{



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
        public string Create(Test test)
        {
            return null;
        }

       
    }
}