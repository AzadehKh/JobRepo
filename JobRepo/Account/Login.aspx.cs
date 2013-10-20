using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace JobRepo.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser.DestinationPageUrl = Request.QueryString["ReturnUrl"];
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            /*We need the following method to execute otherwise the 
             * logged in user won't be Initialized correctly
            */
            Common.InitializeUser(LoginUser.UserName, Context);
        }


 
    }
}
