using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Threading;
using JobRepo.Model;

namespace JobRepo.MVC.Controllers
{
    public class EmployerController : Controller
    {

        IKeywordsPopularity _KeywordsPopularity;
        public EmployerController(IKeywordsPopularity KeywordsPopularity)
        {
            _KeywordsPopularity = KeywordsPopularity;
        }

        // GET: /Employer/
        public ActionResult SeekEmployee(string keyword)
        {

            List<Employee> empees = null;
            ViewData["Message"] = "";

            if (keyword != null)
            {
                string[] filters = keyword.Split(';');

                foreach (string filter in filters)
                    _KeywordsPopularity.SetAsPopular(filter);
                
                using (EmployeeProfileObject Employeeprofile = new EmployeeProfileObject())
                {
                    var temp = Employeeprofile.FilterProfiler(keyword);
                    empees = temp.ToList();
                    
                }

                if (empees == null || empees.Count() == 0)
                    ViewData["Message"] = "No matched record found";
            }


            return View(empees);
        }



    }
}
