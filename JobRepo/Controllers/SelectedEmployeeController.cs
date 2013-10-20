using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobRepo.ActionFilters;
using JobRepo.Model;

namespace JobRepo.MVC.Controllers
{
    [LoggedAsEmployerActionFilter]
    public class SelectedEmployeeController : Controller
    {
        //
        // GET: /SelectedEmployee/
        //[Authorize]
        public ActionResult List(string keyword = "")
        {

            if (keyword == "error")
            {
                throw new HttpException("invalid data has been entered!");
            }

            else
            {
                string[] filters = keyword.Split(';');

                List<Employee> emps = null;
                int EmployerID = Session["EmployerID"] == null ? 0 : Convert.ToInt32(Session["EmployerID"]);
                using (JobRepoDataContext Context = new JobRepoDataContext())
                {
                    if (keyword != "")
                        emps = (from sel in Context.SelectedEmployees.Where(e => e.EmployerID == EmployerID)
                                join emp in Context.Employees on sel.EmployeeID equals emp.EmployeeID
                                join res in Context.Resumes.Where(p => filters.Any(x => p.Keywords.Contains(x))) on emp.EmployeeID equals res.EmployeeID
                                select emp).Distinct().ToList();
                    else
                        emps = (from sel in Context.SelectedEmployees.Where(e => e.EmployerID == EmployerID)
                                join emp in Context.Employees on sel.EmployeeID equals emp.EmployeeID
                                join res in Context.Resumes on emp.EmployeeID equals res.EmployeeID
                                select emp).Distinct().ToList();

                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_AjaxEnabledSelectedEmployee", emps);
                    }

                    return View("List", emps);
                }
            }
        }

    }
}
