using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JobRepo.Model;
using System.Data;
using System.Web.Security;

namespace JobRepo
{
    public partial class EmployerProfile : System.Web.UI.Page
    {
        bool _hasLogo = false;
        protected void Page_Init(object sender, EventArgs e)
        {
            // dvwEmployer.EnableDynamicData(typeof(Employer));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;
            if (Membership.GetUser() != null)
                Session["UserID"] = Membership.GetUser().ProviderUserKey.ToString();
            else
                Session["UserID"] = null;

            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    MultiView1.ActiveViewIndex = 1;
                    dvwEmployer.ChangeMode(DetailsViewMode.Edit);

                    btnPrevious.Visible = false;
                    btnNext.Visible = false;

                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    dvwEmployer.ChangeMode(DetailsViewMode.Insert);
                }
            }


        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "CompanyDetails":

                    if (Common.CreateUser(txtUsername.Text, txtPassword.Text, txtRecoveryEmail.Text
                        , txtQuestion1.Text, txtAnswer1.Text, txtQuestion2.Text, txtAnswer2.Text))
                    {
                        MultiView1.ActiveViewIndex = 1;
                        btnNext.Enabled = false;
                        btnPrevious.Enabled = true;
                    }
                    break;
                case "AccountDetails":

                    MultiView1.ActiveViewIndex = 0;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                     txtRecoveryEmail.Enabled = false;
                     
                     /*
                     * To disable validation in a specific control :
                            Set the control's CausesValidation property to false. 
                       To disable a validation control :
                            Set the validation control's Enabled property to false. 
                       To disable client-side validation :
                            Set the validation control's EnableClientScript property to false.
                     */
                    txtPassword.CausesValidation = false;
                    CustomValidatorpassword.EnableClientScript = false;
                    CustomValidatorpassword.Enabled = false;
                    RequiredFieldValidatorpassword.EnableClientScript = false;
                    RequiredFieldValidatorpassword.Enabled = false;


                    btnPrevious.Enabled = false;
                    btnNext.Enabled = true;
                    break;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (dvwEmployer.CurrentMode == DetailsViewMode.Insert)

                    dvwEmployer.InsertItem(false);
                else
                    dvwEmployer.UpdateItem(false);
            }
        }

 
       

        protected void objDsEmployer_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            Employer item = (Employer)e.InputParameters[0];
            bool UserCreated = true;



            ProfileCommon profile = ProfileCommon.GetProfile();
            profile.SecurityQuestions.Question1 = txtQuestion1.Text;
            profile.SecurityQuestions.Answer1 = txtAnswer1.Text;
            profile.SecurityQuestions.Question2 = txtQuestion2.Text;
            profile.SecurityQuestions.Answer2 = txtAnswer2.Text;
            try
            {
                profile.Save();

            }
            catch
            {
                UserCreated = false;
            }

            if (UserCreated)
            {
                item.UserID = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                saveImage(item);
            }
            else
                e.Cancel = true;
        }

        protected void objDsEmployer_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            Employer item = (Employer)e.InputParameters[0];
            item.UserID = new Guid( Session["UserID"].ToString());
            saveImage(item);
        }


        private void saveImage(Employer item)
        {


            FileUpload logoUploader = (FileUpload)dvwEmployer.FindControl("logoUploader");

            byte[] logo = new byte[logoUploader.PostedFile.ContentLength];
            if (logo.Length > 0)
            {
                HttpPostedFile Image = logoUploader.PostedFile;
                Image.InputStream.Read(logo, 0, (int)logoUploader.PostedFile.ContentLength);


                item.Logo = logo;
            }
            else
                if (ViewState["logo"] != null)
                    item.Logo = (byte[])ViewState["logo"];
        }

        protected void objDsEmployer_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            Employer item=null;
            if (e.ReturnValue !=null)
                item = ((List<Employer>)e.ReturnValue).FirstOrDefault();

            if (item == null)
                /* The user might leave this page after creating a new account 
                    so he/she can log in but she does not have any profie e.g.
                    ProfileID = null
                    so the View should go to the insert mode
                 */
                dvwEmployer.ChangeMode(DetailsViewMode.Insert);
 
            _hasLogo = (item != null && item.Logo != null && item.Logo.Length > 0);
            if (_hasLogo)
            {

                // During Insert and update , DetailsView sets the value of Unbound fields to null 
                // To avoid losing the current values we need to use Viewstate for unbound fields
                ViewState["logo"] = item.Logo;
            }
        }

        protected void imgLogo_DataBinding(object sender, EventArgs e)
        {
            Image imgLogo = (Image)sender;
            imgLogo.Visible = _hasLogo;
        }

        protected void objDsEmployer_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            Session["EmployerID"] = e.ReturnValue;
            //DetailsView Select Event has not been raised after submit/postback 
            //so we need the following code to force the ASP.NET to fetch data again
            Response.Redirect("EmployerProfile.aspx");

        }

        protected void objDsEmployer_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            //DetailsView Select Event has not been raised after submit/postback 
            //so we need the following code to force the ASP.NET to fetch data again
            Response.Redirect("EmployerProfile.aspx");
        }



    }
}