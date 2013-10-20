using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using JobRepo.Model;
using System.Web.SessionState;

namespace JobRepo
{
    public class Common
    {

        public static void InitializeUser(string username ,HttpContext context)
        {
            /*after login ( either through the login control or through the code behind ) , 
            We need the following line of code otherwise Membership.getUser() returns null
             */

            context.Session["EmployerID"] = null;
            context.Session["EmployeeID"] = null;
            FormsAuthentication.SetAuthCookie(username, false /* createPersistentCookie */);

            using (EmployerProfileObject employerprofile = new EmployerProfileObject())
            {
                IEnumerable<Employer> emps = employerprofile.GetProfile(Membership.GetUser(username).ProviderUserKey.ToString());
                Employer employer = emps.FirstOrDefault();
                if (employer != null)
                    context.Session["EmployerID"] = employer.EmployerID;
            }

            using (EmployeeProfileObject Employeeprofile = new EmployeeProfileObject())
            {
                IEnumerable<Employee> empees = Employeeprofile.GetProfile(Membership.GetUser(username).ProviderUserKey.ToString());
                Employee Employee = empees.FirstOrDefault();
                if (Employee != null)
                    context.Session["EmployeeID"] = Employee.EmployeeID;
            }
        }


        public static bool CreateUser(string username
            ,string password , string recoveryEmail
            , string question1, string answer1, string question2, string answer2)
        {
            bool UserCreated = true;
            MembershipUser user = null;


            if (HttpContext.Current.Session["UserID"] == null)
            {
                if (Membership.GetUser(username) == null)
                {
                    user = Membership.CreateUser(username,
                       password,
                       recoveryEmail);

                    if (user != null)
                    {
                        Roles.AddUserToRole(username, "Members");
                        /*We need the following method to execute otherwise the 
                         * logged in user won't be Initialized correctly
                        */
                        Common.InitializeUser(username, HttpContext.Current);

                        ProfileCommon profile = ProfileCommon.GetProfile();
                        profile.SecurityQuestions.Question1 = question1;
                        profile.SecurityQuestions.Answer1 = answer1;
                        profile.SecurityQuestions.Question2 = question2;
                        profile.SecurityQuestions.Answer2 = answer2;
                        profile.Save();

                        HttpContext.Current.Session["UserID"] = user.ProviderUserKey;

                    }
                    else
                    {
                        UserCreated = false;
                    }
                }
                else // The user has already been created but some information like below can be updated
                {
                    ProfileCommon profile = ProfileCommon.GetProfile();
                    profile.SecurityQuestions.Question1 = question1;
                    profile.SecurityQuestions.Answer1 = answer1;
                    profile.SecurityQuestions.Question2 = question2;
                    profile.SecurityQuestions.Answer2 = answer2;
                    profile.Save();

                    HttpContext.Current.Session["UserID"] = Membership.GetUser(username).ProviderUserKey;
                }

            }

            return UserCreated;
        }
    }
}