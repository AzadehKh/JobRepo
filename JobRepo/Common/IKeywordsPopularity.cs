using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobRepo.MVC
{
    public interface IKeywordsPopularity
    {
        void SetAsPopular(string Keyword);
    }
}