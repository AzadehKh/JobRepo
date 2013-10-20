using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JobRepo.Model;

namespace JobRepo
{
    public partial class JobSearch : System.Web.UI.Page
    {
        string whereClause = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfileCommon profile = ProfileCommon.GetProfile();
                txtKeyword.Text = profile.RecentSearch.Keywords;
            }

                
        }

        protected void objDSJob_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters[0] = whereClause;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text != "")
                whereClause = "DD=" + Server.HtmlEncode(txtKeyword.Text);
            if (txtLocation.Text != "")
                whereClause += "&LL=" + Server.HtmlEncode(txtLocation.Text);

            objDSJob.Select();
            lwSearchResult.DataBind();

            ProfileCommon profile = ProfileCommon.GetProfile();
            profile.RecentSearch.Keywords = txtKeyword.Text;
            profile.Save();
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchLocations(string prefixText, int count)
        {

            
            List<string> cities=null;

            using (JobRepoDataContext context = new JobRepoDataContext())
            {

                cities = context.Cities.Where( e => e.CityName.Contains(prefixText))
                    .Select( e=> e.CityName).ToList();
 
                

            }
            return cities;

        }



    }
}