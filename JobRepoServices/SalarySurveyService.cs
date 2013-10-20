using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Xml.Linq;
using System.Reflection;

namespace JobRepoServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SalarySurveyService : ISalarySurveyService
    {


        public IEnumerable<SalarySurvey> FetchSalaries()
        {

            XElement _Xml = XElement.Load(Assembly.GetExecutingAssembly()
    .GetManifestResourceStream("JobRepoServices.SalaryRepository.xml"));

            var advQuery =
            from adv in _Xml.Descendants("Salary")
            orderby adv.Element("Role").Value
            select new SalarySurvey
            {

                Role = adv.Element("Role").Value,
                MinSalary = adv.Element("MinSalary").Value,
                MaxSalary = adv.Element("MaxSalary").Value,
                AverageSalary = adv.Element("AverageSalary").Value

            };

            return advQuery;
        }
        public SalarySurvey[] GetAllRoles()
        {
            return FetchSalaries().ToArray();
        }

        public SalarySurvey[] GetRole(string role)
        {
            return FetchSalaries()
                .Where(e => e.Role.Contains(role))
                    .ToArray();
        }


    }

}