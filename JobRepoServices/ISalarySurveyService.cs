using System.ServiceModel;
using System.Xml.Linq;

namespace JobRepoServices
{
    [ServiceContract]
    public interface ISalarySurveyService
    {
        [OperationContract]
        SalarySurvey[] GetAllRoles();

        [OperationContract]
        SalarySurvey[] GetRole(string role);
         

    }


}