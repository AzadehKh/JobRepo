using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

namespace JobRepo
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            if (user != null && user.IsApproved)
            {
               // FormsAuthentication.SetAuthCookie(user.UserName, false /* createPersistentCookie */);

                this.WebPartManager1.DisplayMode = WebPartManager.DesignDisplayMode;
            }
        }
    }
}