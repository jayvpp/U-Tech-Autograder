using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace AutoGrader.Controllers
{

    static class UserIdentifierHelper
    {
        public static bool IsStudent(this IPrincipal principal) => principal.IsInRole("student");
        public static bool IsProfessor(this IPrincipal principal) => principal.IsInRole("professor");
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsProfessor())
            {
                ViewBag.Name = User.Identity.Name;
                return RedirectToAction("Index","Professor");
            }
            if (User.IsStudent())
            {
                ViewBag.Name = User.Identity.Name;
                return RedirectToAction("Index", "Student");
            }
            else
                return View();
        }
        [Authorize(Roles = "professor")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "student")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View("Create");
        }
    }
}