using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using JobRepo.MVC.Binders;

namespace JobRepo.Model

{

    [ModelBinder(typeof(DateTimeModelBinder))]
    public class ResumeDTO
    {
        [Key]
        public int resumeID { get; set; }
        public int employeeID { get; set; }
        public string Title { get; set; }
        public System.Byte[] Description { get; set; }
        public DateTime PostedDate { get; set; }
        public string Keywords { get; set; }

    }

}