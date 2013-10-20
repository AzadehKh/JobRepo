using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobRepo.Model;

namespace JobRepo.Handlers
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string ImageType = string.Empty;

            using (JobRepoDataContext ctx = new JobRepoDataContext())
            {
                String EEE = context.Request.QueryString["employerid"];
                int employerid = Convert.ToInt32(context.Request.QueryString["employerid"]);

                Employer emp = ctx.Employers.FirstOrDefault(e => e.EmployerID == employerid);
                if (emp != null && emp.Logo != null)
                {

                    //context.Response.ContentType ="jpg"; 
                    context.Response.BinaryWrite(emp.Logo);

                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}