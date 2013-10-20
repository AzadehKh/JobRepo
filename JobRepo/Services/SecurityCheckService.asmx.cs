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
    /// Summary description for SecurityCheckService
    /// </summary>
    [WebService(Namespace = "http://www.JobPro.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SecurityCheckService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool IsValidAnswerToQuestion1(string Answer1)
        {

            ProfileCommon profile = ProfileCommon.GetProfile();
            string OriANswer = profile.SecurityQuestions.Answer1.ToLower();
            bool Equals =false;
            if (OriANswer != "")
                Equals = OriANswer.Equals(Answer1.ToLower());

            return Equals;

        }


        [WebMethod]
        public bool IsValidAnswerToQuestion2(string Answer2)
        {

            ProfileCommon profile = ProfileCommon.GetProfile();
            string OriANswer = profile.SecurityQuestions.Answer2.ToLower();
            bool Equals = false;
            if (OriANswer != "")
                Equals = OriANswer.Equals(Answer2.ToLower());

            return Equals;

        }
    }
}
