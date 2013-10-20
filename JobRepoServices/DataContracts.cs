using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JobRepoServices
{
    [DataContract]
    public class SalarySurvey
    {

        string _Role = "";
        [DataMember]
        public string Role
        {
            get { return _Role; }
            set { _Role = value; }
        }


        string _MinSalary = "";
        [DataMember]
        public string MinSalary
        {
            get { return _MinSalary; }
            set { _MinSalary = value; }
        }

        string _MaxSalary = "";
        [DataMember]
        public string MaxSalary
        {
            get { return _MaxSalary; }
            set { _MaxSalary = value; }
        }

        string _AverageSalary = "";
        [DataMember]
        public string AverageSalary
        {
            get { return _AverageSalary; }
            set { _AverageSalary = value; }
        }
    }
}
