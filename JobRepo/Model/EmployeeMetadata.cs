using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobRepo.Model
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
        
    }


    public class EmployeeMetadata
    {
        [StringLength(100)]
        public string FirstName { get; set; }   


        [StringLength(100)]
        public string LastName { get; set; }   

    }
}