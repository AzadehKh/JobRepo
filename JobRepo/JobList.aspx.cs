using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobRepo
{
    public partial class JobList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["JobID"] = null;
            btnAdd.Enabled = (Session["EmployerID"] != null);
        }

        protected void grdJob_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditJob")
            {
                Session["JobID"] =e.CommandArgument;
                Response.Redirect("JobEditor.aspx" );
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["JobID"] = null; 
            Response.Redirect("JobEditor.aspx");
        }
    }
}