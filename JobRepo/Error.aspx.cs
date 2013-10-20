using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobRepo
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowError();
        }

        private void ShowError()
        {
            string err = "";
            if (Server.GetLastError() != null)
            {

                Exception objErr = Server.GetLastError();
                err = "<b>An error occurred while processing your request</b><hr><br>" +
                        "<br><b>Error in: </b>" + Request.Url.ToString() +
                        "<br><b>Error Message: </b>" + GetInnerException(objErr) +
                        "<br><b>Stack Trace:</b><br>" +
                        objErr.StackTrace.ToString();

                if (Server.GetLastError().GetBaseException() != null)
                {
                    Exception objbaseErr = Server.GetLastError().GetBaseException();
                    err = err + "<br><br><b> BaseException </b>" +
                    "<br><b>Error Message: </b>" + objbaseErr.Message.ToString() +
                    "<br><b>Stack Trace:</b><br>" +
                    objbaseErr.StackTrace.ToString();
                }
            }
            this.litContent.Text = err;
            //Response.Write(err);
            Server.ClearError();
        }

        private string GetInnerException(Exception err)
        {
            string errormessage ="";
            errormessage = err.Message + "<br>";
            if (err.InnerException != null)
            {
                errormessage += "<br>" + GetInnerException(err.InnerException) ;
            }

           return errormessage;
        }
    }
}