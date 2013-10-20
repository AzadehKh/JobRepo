using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JobRepo.Services;
using JobRepo.Model;
using System.Data.Services.Client;

namespace JobRepo
{
    public partial class JobReviewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UpdateJobViewedCount();
            Response.Cache.AddValidationCallback(new HttpCacheValidateHandler(Validate), null);
        }

        public void Validate(HttpContext context, Object data, ref HttpValidationStatus status)
        {
            
         //   var request = HttpContext.Current.Request;
            var request = context.Request;
            if (request.QueryString["JJ"] == null)
                status = HttpValidationStatus.Invalid;
            else if (request.QueryString["JJ"] == "" || request.QueryString["JJ"] == "0")
                status = HttpValidationStatus.IgnoreThisRequest;
            else
                status = HttpValidationStatus.Valid;

        }

        protected void UpdateJobViewedCount()
        {
            var request = HttpContext.Current.Request;
            Uri svcUri = new Uri(Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
                + "Services/TopTenWcfDataService.svc");
            
            try
            {
                TopTenWcfDataServiceRef.JobRepoDataContext context
                     = new TopTenWcfDataServiceRef.JobRepoDataContext(svcUri);
                int JobID = (request.QueryString["JJ"] != null ? Convert.ToInt32(request.QueryString["JJ"]) : 0);



                /*The following query will be transfered to
                 http://localhost:50339/Services/TopTenWcfDataService.svc/Jobs()?$filter=JobID eq 15
                 * http://localhost:50339/Services/TopTenWcfDataService.svc/Jobs()?$filter=JobID%20eq%2015
                 */
                DataServiceQuery<TopTenWcfDataServiceRef.Job> jobs = context.Jobs
                                     .AddQueryOption("$filter", "JobID eq " + JobID.ToString());
                                                       
                var job = jobs.Single();

                /*
                    We can get the same result using LINQ Query:
                    var job = (from j in context.Jobs
                               where j.JobID.Equals(JobID)
                               select j).Single();
                    it will will be transfered to
                    http://localhost:50339/Services/TopTenWcfDataService.svc/Jobs(15)
                 */

                if (job != null)
                {

                    job.Viewed += 1;
                    context.UpdateObject(job);

                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }


  





    }
}