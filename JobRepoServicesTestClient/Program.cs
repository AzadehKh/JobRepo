using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobRepoServicesTestClient.SalarySurveyRef;

namespace JobRepoServicesTestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            SalarySurveyServiceClient client = new SalarySurveyServiceClient();

            foreach (SalarySurvey ss in client.GetAllRoles())
                Console.WriteLine(ss.Role + "  " + ss.MinSalary + "  " + ss.MaxSalary + "  " + ss.AverageSalary);

            Console.ReadLine();
            // Always close the client.
            client.Close();
        }
    }
}
