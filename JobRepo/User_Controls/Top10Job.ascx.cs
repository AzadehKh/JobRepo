using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace JobRepo.User_Controls
{
    public partial class Top10Job : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                HttpContext.Current.Session["SelectedJob"] = "";

            }
            catch  {}
        }

        [ConnectionConsumer("Selected Job", "GetSelectedJob")]
        public void GetSelectedJob(string JobName)
        {
            try
            {
                Session["SelectedJob"] = JobName;
            }
            catch { }
        }
    }
}