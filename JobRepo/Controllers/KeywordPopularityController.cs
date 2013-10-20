using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobRepo.MVC.Services;
using JobRepo.Model;

namespace JobRepo.MVC.Controllers
{
    public class KeywordPopularityController : Controller
    {
        //
        // GET: /KeywordPopularity/

        public ActionResult KeywordPopularity()
        {
            return View();
        }

        public JsonResult Keywords()
        {
            object Keywords = null;
            using (JobRepoDataContext Context = new JobRepoDataContext())
            {
                Keywords = (from i in Context.KeywordPopularities.Select(e => e.Keyword).Distinct()
                           select new
                           {
                               ID = i,
                               Name = i
                           }).ToList();
            }
            return Json(Keywords, JsonRequestBehavior.AllowGet);

        }

        //This method has been moved to the PopularityService
        //public JsonResult KeywordCount(string Keyword)
        //{
        //    object res = null;   
        //    using (JobRepoDataContext Context = new JobRepoDataContext())
        //    {
        //        res = Context.KeywordPopularity.Where(e => e.Keyword.Contains(Keyword)).ToList();
        //    }
 
        //    return Json(res, JsonRequestBehavior.AllowGet);
 
        //}


        [OutputCache(Duration = 30, VaryByParam = "Keyword")]
        public PartialViewResult KeywordCount(string Keyword)
        {
            IKeywordService service = new KeywordService();
            return PartialView("_AJAXEnabledServicedKeywordCount", service.KeywordCount(Keyword));
        }
        
    }
}
