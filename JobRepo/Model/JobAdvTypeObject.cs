using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.Xml.Linq;
using System.ComponentModel;


namespace JobRepo.Model
{

    [Table(Name = "JobAdvTypeDto")]
    public class JobAdvTypeDto
    {
        private int _ID = 0;
        [Column(IsPrimaryKey = true, Storage = "_ID", Name = "ID")]
        public int ID
        {
            get

            { return _ID; }

            set
            {
                _ID = value;
            }
        }


        private int _Ordering = 0;
        [Column(Storage = "_Ordering", Name = "Ordering")]
        public int Ordering
        {
            get

            { return _Ordering; }

            set
            {
                _Ordering = value;
            }
        }


        private String _Price = "";
        [Column(Storage = "_Price", Name = "Price")]
        public String Price
        {
            get

            { return _Price; }

            set
            {
                _Price = value;
            }
        }


        private bool _IsFree = false;
        [Column(Storage = "_IsFree", Name = "IsFree")]
        public bool IsFree
        {
            get

            { return _IsFree; }

            set
            {
                _IsFree = value;
            }
        }


        private string _Type = "";
        [Column(Storage = "_Type", Name = "Type")]
        public string Type
        {
            get

            { return _Type; }

            set
            {
                _Type = value;
            }
        }


        private string _Description = "";
        [Column(Storage = "_Description", Name = "Description")]
        public string Description
        {
            get

            { return _Description; }

            set
            {
                _Description = value;
            }
        }

        private string _Offer = "";
        [Column(Storage = "_Offer", Name = "Offer")]
        public string Offer
        {
            get

            { return _Offer; }

            set
            {
                _Offer = value;
            }
        }
        
    }

    [DataObject()]
    public class JobAdvTypeObject : IDisposable
    {

        JobRepoDataContext context = new JobRepoDataContext();
        public JobAdvTypeObject()
        {

        }


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<JobAdvTypeDto> GetAllActiveAdvs()
        {
            /*
            // Using either Context.Request or HttpContext.Current.Request is correct
            string fullpath = HttpContext.Current.Request.MapPath(@"~\App_data\JobAdvType.xml");

            XElement _advpXml = XElement.Load(fullpath);


            var advQuery =
            from adv in _advpXml.Descendants("Advertisement")
            where adv.Attribute("Status").Value == "Active"
            orderby adv.Element("Ordering").Value
            select new JobAdvTypeDto
            {
                ID =Convert.ToInt32( adv.Element("ID").Value),
                Offer = adv.Element("Offer").Value,
                Price = "$ " + adv.Element("Price").Value,
                Type = adv.Element("Type").Value,
                Description = adv.Element("Description").Value
                .Replace("*", "<br /> * ")
            };
           
            return advQuery.ToList();
            */

            return GetAdvs().ToList();
        }





       [DataObjectMethod(DataObjectMethodType.Select)]
       public IEnumerable<JobAdvTypeDto> GetAdvs()
       {
           // Using either Context.Request or HttpContext.Current.Request is correct
           string fullpath = HttpContext.Current.Request.MapPath(@"~\App_data\JobAdvType.xml");

           XElement _advpXml = XElement.Load(fullpath);


           var advQuery =
           from adv in _advpXml.Descendants("Advertisement")
           where adv.Attribute("Status").Value == "Active"
           orderby adv.Element("Ordering").Value
           select new JobAdvTypeDto
           {
               ID = Convert.ToInt32(adv.Element("ID").Value),
               Offer = adv.Element("Offer").Value,
               Price = "$ " + adv.Element("Price").Value,
               Type = adv.Element("Type").Value,
               Description = adv.Element("Description").Value
               .Replace("*", "<br /> * ")
           };

           return advQuery;
       }


    }

}