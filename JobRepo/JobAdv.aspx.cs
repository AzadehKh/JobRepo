using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JobRepo.Model;
using JobRepo.Services;

namespace JobRepo
{

    public partial class JobAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Cache["JobAdvTypeDto"] != null)
                    rptAdv.DataSource = Cache["JobAdvTypeDto"];
                else
                {
                    JobAdvTypeObject jobAdvService = new JobAdvTypeObject();
                    List<JobAdvTypeDto> data = jobAdvService.GetAllActiveAdvs();
                    Cache.Insert("JobAdvTypeDto", data,
                    new System.Web.Caching.CacheDependency(Server.MapPath(@"~\App_data\JobAdvType.xml")),
                    System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0, 0));
                    rptAdv.DataSource = data;

                }
                rptAdv.DataBind();

            }

        }



    }




}

