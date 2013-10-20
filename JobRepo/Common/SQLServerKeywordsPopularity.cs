using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobRepo.Model;


namespace JobRepo.MVC
{
    public class SQLServerKeywordsPopularity :IKeywordsPopularity
    {

        public void SetAsPopular(string Keyword)
        {
            using (JobRepoDataContext Context = new JobRepoDataContext())
            {
                Context.SetKeywordsPopularity(Keyword);
            }
        }

    }
}