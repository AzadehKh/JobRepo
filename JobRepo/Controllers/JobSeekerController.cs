using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using JobRepo.Model;
using JobRepo.ActionFilters;

namespace JobRepo.MVC.Controllers
{
    public class JobSeekerController : Controller
    {
        //
        // GET: /JobSeeker/Profile
        [LoggedAsEmployeeActionFilter]
        public ActionResult UpdateProfile()
        {
            Employee emp = null;
            using (EmployeeProfileObject Employeeprofile = new EmployeeProfileObject())
            {
                int EmployeeID = Session["EmployeeID"] == null ? 0 : Convert.ToInt32(Session["EmployeeID"]);
                if (EmployeeID == 0)
                {
                    return RedirectToAction("CreateProfile");
                }

                IEnumerable<Employee> empees = Employeeprofile.GetProfilebyID(EmployeeID);
                emp = empees.FirstOrDefault();
            }
            ViewData.Model = emp;
            return View();
        }


        //Sending Value to paramters through "ViewForm" ( i.e. BeginForm tag) 
        //As we want to send some value to the server , HTMLRequestverb should be POST
        [ValidateInput(true)]
        [AcceptVerbs(HttpVerbs.Post)]
        [LoggedAsEmployeeActionFilter]
        public ViewResult UpdateProfile(FormCollection collection)
        {
            int EmployeeID = Session["EmployeeID"] == null ? 0 : Convert.ToInt32(Session["EmployeeID"]);


            using (JobRepoDataContext Context = new JobRepoDataContext())
            {
                Employee emp = Context.Employees
                    .FirstOrDefault(e => e.EmployeeID == EmployeeID);

                if (emp != null)
                {
                    try
                    {
                        UpdateModel(emp, new String[] { "FirstName", "LastName", "Phone", "Email", "JobTitle" }
                            , collection);

                        if (ModelState.IsValid)
                            Context.SaveChanges();
                    }
                    catch
                    {
                    
                    }
                }
                return View(emp);

            }
        }



        public ActionResult CreateProfile()
        {
            int EmployeeID = Session["EmployeeID"] == null ? 0 : Convert.ToInt32(Session["EmployeeID"]);
            if (EmployeeID > 0)
                return RedirectToAction("UpdateProfile");
            else
                return View();
        }

        //Sending Value to paramters through "ViewForm" ( i.e. BeginForm tag) 
        //As we want to send some value to the server , HTMLRequestverb should be POST
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateProfile(
            [Bind(Include = "FirstName,LastName,Phone,Email,JobTitle,UserName,Password,Question1,Answer1,Question2,Answer2", Exclude = "UserID")]EmployeeDTO emp)
        {

            if (String.IsNullOrEmpty(emp.UserName))
                ModelState.AddModelError("UserName", "UserName cannot be empty");

            if (String.IsNullOrEmpty(emp.Password))
                ModelState.AddModelError("Password", "Password cannot be empty");

            if (String.IsNullOrEmpty(emp.Question1))
                ModelState.AddModelError("Question1", "Question1 cannot be empty");

            if (String.IsNullOrEmpty(emp.Answer1))
                ModelState.AddModelError("Answer1", "Answer1 cannot be empty");

            if (String.IsNullOrEmpty(emp.Question2))
                ModelState.AddModelError("Question2", "Question2 cannot be empty");

            if (String.IsNullOrEmpty(emp.Answer2))
                ModelState.AddModelError("Answer2", "Answer2 cannot be empty");

            if (String.IsNullOrEmpty(emp.FirstName))
                ModelState.AddModelError("FirstName", "FirstName cannot be empty");

            if (String.IsNullOrEmpty(emp.LastName))
                ModelState.AddModelError("LastName", "LastName cannot be empty");

            if (String.IsNullOrEmpty(emp.Phone))
                ModelState.AddModelError("Phone", "Phone cannot be empty");

            if (String.IsNullOrEmpty(emp.Email))
                ModelState.AddModelError("Email", "Email cannot be empty");

            if (String.IsNullOrEmpty(emp.JobTitle))
                ModelState.AddModelError("JobTitle", "JobTitle cannot be empty");


            if (ModelState.IsValid)
            {

                if (Common.CreateUser(emp.UserName, emp.Password, emp.Email, emp.Question1, emp.Answer1, emp.Question2, emp.Answer2))
                {

                    using (JobRepoDataContext Context = new JobRepoDataContext())
                    {
                        Employee employee =new Employee()
                        { 
                            Email = emp.Email ,
                            FirstName  =emp.FirstName,
                            LastName=emp.LastName,
                            JobTitle =emp.JobTitle,
                            Phone=emp.Phone,
                            UserID=Guid.Parse(Session["UserID"].ToString())
                        };

                        Context.Employees.AddObject(employee);
                        Context.SaveChanges();
                        Session["EmployeeID"] = employee.EmployeeID;
                        return RedirectToAction("UpdateProfile");
                    }
                }
                
            }

            return View();
        }

        
        [LoggedAsEmployeeActionFilter]
        //[Authorize]
        public ActionResult UploadResume()
        {
            int EmployeeID = Session["EmployeeID"] == null ? 0 : Convert.ToInt32(Session["EmployeeID"]);
            if (EmployeeID > 0 )
                return View();
            else
               return Redirect(Request.UrlReferrer.ToString());

        }

        [AcceptVerbs(HttpVerbs.Post)]
        [LoggedAsEmployeeActionFilter]
        public ActionResult UploadResume(FileModel model)
        {
            int EmployeeID = Session["EmployeeID"] == null ? 0 : Convert.ToInt32(Session["EmployeeID"]);
            if (EmployeeID > 0 && ModelState.IsValid)
            {

                byte[] uploadedfile = new byte[model.File.ContentLength];
                if (uploadedfile.Length > 0)
                {
                    HttpPostedFileBase file = model.File;
                    file.InputStream.Read(uploadedfile, 0, (int)model.File.ContentLength);


                    using (JobRepoDataContext Context = new JobRepoDataContext())
                    {

                        Resume entity = new Resume()
                        {
                            Title = model.Title,
                            PostedDate = DateTime.Now,
                            Description = uploadedfile,
                            Keywords = model.Keywords,
                            EmployeeID = EmployeeID
                        };
                        Context.Resumes.AddObject(entity);
                        Context.SaveChanges();
                    }
                }

                return RedirectToAction("ManageResumes");

            }
            return View();
        }


        // GET: 
        //[Authorize]
        [LoggedAsEmployeeActionFilter]
        public ActionResult ManageResumes()
        {

                /*
                  We can use TempData[] rather than Session[] ,The difference between this two is that the TempData 
                   object will be deleted from the session when it is read. TempData is just a wrapper of the session.
                */
//            List<Resume> res = null;
            List<ResumeDTO> res = null;
            int EmployeeID = Session["EmployeeID"] == null ? 0 : Convert.ToInt32(Session["EmployeeID"]);
            if (EmployeeID > 0 )
            {
                using (JobRepoDataContext Context = new JobRepoDataContext())
                {

                    res = ( from r in Context.Resumes.Where(e => e.EmployeeID == EmployeeID)
                            select new ResumeDTO
                            {
                                 Description = r.Description,
                                 employeeID =r.EmployeeID,
                                 Keywords =r.Keywords,
                                 PostedDate  =r.PostedDate,
                                 resumeID =r.ResumeID,
                                 Title  =r.Title
                            }).ToList();

                   // res = Context.Resume.Where(e => e.EmployeeID == EmployeeID).ToList();
                    return View(res);
                }
            }
            return View(res);

            
        }

        //For Delete Action , we should always "POST" (for security reasons)
        [AcceptVerbs(HttpVerbs.Get)]
        [LoggedAsEmployeeActionFilter]
        public ActionResult DeleteResume(int id)
        {
            using (JobRepoDataContext Context = new JobRepoDataContext())
            {

                var resume = Context.Resumes.Where(e => e.ResumeID == id).First();
                Context.DeleteObject(resume);
                Context.SaveChanges();
            }
            return RedirectToAction("ManageResumes");
        }


        [ActionName("EmployeeDetails")]
        public ActionResult ShowEmployeeDetails(int id)
        {
            Employee emp = null;
            using (EmployeeProfileObject Employeeprofile = new EmployeeProfileObject())
            {

                emp = Employeeprofile.GetProfilebyID(id).FirstOrDefault();
            }


            return View(emp);
        }

        [LoggedAsEmployerActionFilter]
        public string SelectEmployee(int employeeID)
        {
            int employerID = Session["EmployerID"] == null ? 0 : Convert.ToInt32(Session["EmployerID"]);
            using (JobRepoDataContext Context = new JobRepoDataContext())
            {
                Thread.Sleep(300); // added for test purpose
                Context.SelectedEmployees.AddObject(
                    new SelectedEmployee() { EmployeeID = employeeID, EmployerID = employerID });
                Context.SaveChanges();
            }

            return "The employee has been added to your selected List";
        }

    }
}
