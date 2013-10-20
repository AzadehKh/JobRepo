using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using JobRepo.Model;

namespace JobRepo.Services
{
    //   [JSONPSupportBehavior]
    public class TopTenWcfDataService : DataService<JobRepoDataContext>
    {

        public static void InitializeService(DataServiceConfiguration config)
        {

            /*The 10 Top Jobs can be returned eaither by using 
                this URL( notice that  Query options $expand, $filter, $orderby, $skip and $top can be applied as well)
                http://localhost/TopTenWcfDataService.svc/Get10TopJobs
                or By using this URL directly:
                 http://localhost/TopTenWcfDataService.svc/Jobs
             */
            config.SetEntitySetAccessRule("Jobs", EntitySetRights.All);
            config.SetServiceOperationAccessRule("Get10TopJobs", ServiceOperationRights.AllRead);

            config.SetEntitySetPageSize("*", 25);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {
            //Cache for a minute based on querystring            
            HttpContext context = HttpContext.Current;
            HttpCachePolicy c = HttpContext.Current.Response.Cache;
            c.SetCacheability(HttpCacheability.ServerAndPrivate);
            c.SetExpires(HttpContext.Current.Timestamp.AddSeconds(60));
            c.VaryByHeaders["Accept"] = true;
            c.VaryByHeaders["Accept-Charset"] = true;
            c.VaryByHeaders["Accept-Encoding"] = true;
            c.VaryByParams["*"] = true;
        }


        /*
         * Notice that if we return IEnumerable rather than IQueryable , 
         * Query options $expand, $filter, $orderby, $skip and $top CANNOT be applied to the requested resource
         * so By keeping the return as IQueryable we can access the data by using any query options:
         * for example: http://localhost/TopTenWcfDataService.svc/Get10TopJobs?$filter=Title%20eq%20'.NET%20Developer'
         * if we want to send selectedjob as well:
         *  for example: http://localhost/TopTenWcfDataService.svc/Get10TopJobs?selectedjob='developer'$filter=Title%20eq%20'.NET%20Developer'
         */
        [WebGet(ResponseFormat=WebMessageFormat.Json)]
        public IQueryable<Job> Get10TopJobs(string selectedjob)
        {

            if (selectedjob == null)
                selectedjob = "";
            return from jc in this.CurrentDataSource.Jobs
                   .OrderByDescending(e => e.Viewed)
                   .Where(e => (selectedjob == "" || e.Title.Contains(selectedjob)))
                   .Take(10)
                   select jc;


        }


    }

}