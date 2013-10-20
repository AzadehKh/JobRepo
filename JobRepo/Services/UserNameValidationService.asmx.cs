using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using JobRepo.Model;
using System.Web.Security;

namespace JobRepo.Services
{
    /// <summary>
    /// Summary description for UserNameValidationService
    /// </summary>
    [WebService(Namespace = "http://www.JobPro.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserNameValidationService : System.Web.Services.WebService
    {
       
        [WebMethod]
        public bool IsValidUserName(string username)
        {
            
            bool isvalid = false;


            if (username != "" && username.Length >= Membership.MinRequiredPasswordLength)
            {
                using (JobRepoDataContext context = new JobRepoDataContext())
                {

                    var query = from MembershipUser user in Membership.GetAllUsers()
                                //Notice that you  cannot user Lambda where .Where ( e => e. ....) 
                                //instead , you need to use by LINQ Where operator: where user.....
                                where user.UserName.ToUpper().Equals(username.ToUpper()) 
                                select user;
                                

                    //IQueryable is not serializable so if we need to return the result ,
                    //it should be returned as list :  query.ToList();
                    isvalid = (query.Count() == 0);

                }
            }
            return isvalid;
            
        }
    }
}
