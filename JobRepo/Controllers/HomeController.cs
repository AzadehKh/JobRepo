using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobRepo.MVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            ViewData["Message"] = "Please use the above menu to navigate our site";
            return View();
        }

        public ActionResult Login(string message)
        {
            ViewData["Message"] = message;
            return View("Index");
        }

    }
}
