using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace JobRepo.User_Controls
{
    public partial class SelectJob : System.Web.UI.UserControl
    {
        private string _Jobname = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _Jobname = txtJob.Text;
        }

        [ConnectionProvider("Selected Job", "GetJobName")]
        public string GetJobName()
        {
            return _Jobname;
        }
    }
}