using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoGrader.Controllers
{
    public class GraderController : Controller
    {
        // GET: Grader
        public ActionResult Index()
        {
            return View();
        }
    }
}