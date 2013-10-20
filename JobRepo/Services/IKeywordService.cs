using System;

using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
namespace JobRepo.MVC.Services
{
    [ServiceContract]
    interface IKeywordService
    {
        [OperationContract]
        List<KeywordPopularityDTO> KeywordCount(string Keyword);
    }
}
