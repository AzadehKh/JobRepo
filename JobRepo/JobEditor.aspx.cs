using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JobRepo.Services;
using JobRepo.Model;

namespace JobRepo
{
    public partial class JobEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["JobID"] != null) 
                {
                    dvJob.ChangeMode(DetailsViewMode.Edit);
                }
                else
                {
                    dvJob.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (dvJob.CurrentMode == DetailsViewMode.Insert)

                    dvJob.InsertItem(false);
                else
                    dvJob.UpdateItem(false);
            }
        }

        protected void objDSJob_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            Response.Redirect("JobList.aspx", true);
        }

        protected void objDSJob_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            Session["JobID"] = e.ReturnValue;
            Response.Redirect("JobList.aspx", true);
        }

        protected void objDSJob_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            JobDto item = (JobDto)e.InputParameters[0];
            item.JobID = Convert.ToInt32(Session["JobID"]);

            item.EmployerID = (int)Session["EmployerID"];
            item.Status = "A"; //Unpaid

        }

        protected void objDSJob_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            JobDto item = (JobDto)e.InputParameters[0];


 
            item.EmployerID = (int)Session["EmployerID"];
            item.Status = "A"; //Unpaid
            item.PostedDate = DateTime.Now;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobList.aspx", true);
        }



        protected void lnkBtnJobAdv_Click(object sender, EventArgs e)
        {
            Server.Transfer("JobAdv.aspx" , true);
        }


    }
}