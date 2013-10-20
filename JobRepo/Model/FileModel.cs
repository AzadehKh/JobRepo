using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Web.Mvc;

namespace JobRepo.Model
{
   
    public class FileModel
    {
        public HttpPostedFileBase _File;
        [Required
        , FileExtensions(Extensions="docx,pdf" , ErrorMessage="Specify a word or pdf file"  )]
        public HttpPostedFileBase File 
        {
            get { return _File; }
            set { _File = value; }
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Keywords { get; set; }
    }
}