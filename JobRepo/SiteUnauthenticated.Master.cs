using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace JobRepo
{
    public partial class SiteUnauthenticated : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            notice that GetNumberOfUsersOnline() shows the logged in users only 
             * and it doesn't have any info about the guest users.
             * another problem about the method is that it doesn't decrease the number 
             * when the user logs out so the number is not accurate.
             * to fix this problem there are some few solutions explained here:
                http://weblogs.asp.net/davidyancey/
             * and here:
             * http://stackoverflow.com/questions/11446036/membership-getnumberofusersonline-does-not-return-correct-values
             
             */
            UsersOnlineLabel.Text = Membership.GetNumberOfUsersOnline().ToString();

        }


        protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["EmployerID"] = null;
            Session["JobID"] = null;

            Session["EmployeeID"] = null;

            Session.Abandon();

            FormsAuthentication.SignOut();


        }


    }
}