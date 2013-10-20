using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JobRepo.SalarySurveyRef;

namespace JobRepo
{
    public partial class SalarySurvey : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            using (SalarySurveyServiceClient client = new SalarySurveyServiceClient())
            {
                grdGuide.DataSource =client.GetAllRoles();
                grdGuide.DataBind();

                client.Close();
                
            }
             
        }


    }
}