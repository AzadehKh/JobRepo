using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using JobRepo.Model;

namespace JobRepo.MVC.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKeywordService" in both code and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class KeywordService : IKeywordService
    {
        public List<KeywordPopularityDTO> KeywordCount(string Keyword)
        {
            List<KeywordPopularityDTO> res = null;
            using (JobRepoDataContext Context = new JobRepoDataContext())
            {
                res = (from i in Context.KeywordPopularities.Where(e => e.Keyword.Contains(Keyword))
                      select new KeywordPopularityDTO { Keyword = i.Keyword , Count = i.Count })
                      .ToList();
            }

            return res;

        }
    }

    [DataContract]
    public class KeywordPopularityDTO
    {
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public int Count { get; set; }
    }

}
