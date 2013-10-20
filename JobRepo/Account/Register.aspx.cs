using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobRepo.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
 

            /*We need the following method to execute otherwise the 
             * logged in user won't be Initialized correctly
            */
            Common.InitializeUser(RegisterUser.UserName, Context);

            //Add user to the role 'Members'
            Roles.AddUserToRole(RegisterUser.UserName, "Members");

        }

        protected void RegisterUser_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {

            //save Security Questions in Profile:
            ProfileCommon profile = ProfileCommon.GetProfile();
            profile.SecurityQuestions.Question1 = txtQuestion1.Text;
            profile.SecurityQuestions.Answer1 = txtAnswer1.Text;
            profile.SecurityQuestions.Question2 = txtQuestion2.Text;
            profile.SecurityQuestions.Answer2 = txtAnswer2.Text;
            profile.Save();


            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }



    }
}
