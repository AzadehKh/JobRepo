using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using LinqKit;
using System.Text.RegularExpressions;


namespace JobRepo.Model
{

  
    [Table(Name = "JobDto")]
    public class JobDto
    {
        public JobDto()
        {
        }
        private String _Title = "";
        [Column(Storage = "_Title", Name = "Title")]
        public String Title
        {
            get

            { return _Title; }

            set
            {
                _Title = value;
            }
        }

        private String _Description = "";
        [Column(Storage = "_Description", Name = "Description")]
        public String Description
        {
            get

            { return _Description; }

            set
            {
                _Description = value;
            }
        }


        private String _ShortDescription = "";
        [Column(Storage = "_ShortDescription", Name = "ShortDescription")]
        public String ShortDescription
        {
            get

            { return _ShortDescription; }

            set
            {
                _ShortDescription = value;
            }
        }


        private int _JobID = 0;
        [Column(Storage = "_JobID", Name = "JobID")]
        public int JobID
        {
            get

            { return _JobID; }

            set
            {
                _JobID = value;
            }
        }



        private int _EmployerID = 0;
        [Column(Storage = "_EmployerID", Name = "EmployerID")]
        public int EmployerID
        {
            get

            { return _EmployerID; }

            set
            {
                _EmployerID = value;
            }
        }



        private DateTime _PostedDate;
        [Column(Storage = "_PostedDate", Name = "PostedDate")]
        public DateTime PostedDate
        {
            get

            { return _PostedDate; }

            set
            {
                _PostedDate = value;
            }
        }


        private DateTime _ValidFrom;
        [Column(Storage = "_ValidFrom", Name = "ValidFrom")]
        public DateTime ValidFrom
        {
            get

            { return _ValidFrom; }

            set
            {
                _ValidFrom = value;
            }
        }

        private DateTime _ValidTo ;
        [Column(Storage = "_ValidTo", Name = "ValidTo")]
        public DateTime ValidTo
        {
            get

            { return _ValidTo; }

            set
            {
                _ValidTo = value;
            }
        }

        private String _SalaryFrom = "";
        [Column(Storage = "_SalaryFrom", Name = "SalaryFrom")]
        public String SalaryFrom
        {
            get

            { return _SalaryFrom; }

            set
            {
                _SalaryFrom = value;
            }
        }

        private String _SalaryTo = "";
        [Column(Storage = "_SalaryTo", Name = "SalaryTo")]
        public String SalaryTo
        {
            get

            { return _SalaryTo; }

            set
            {
                _SalaryTo = value;
            }
        }

        private String _SalaryRange = "";
        [Column(Storage = "_SalaryRange", Name = "SalaryRange")]
        public String SalaryRange
        {
            get

            { return _SalaryRange; }

            set
            {
                _SalaryRange = value;
            }
        }

        private String _ValidationRange = "";
        [Column(Storage = "_ValidationRange", Name = "ValidationRange")]
        public String ValidationRange
        {
            get

            { return _ValidationRange; }

            set
            {
                _ValidationRange = value;
            }
        }

        private String _JobType = "";
        [Column(Storage = "_JobType", Name = "JobType")]
        public String JobType
        {
            get

            { return _JobType; }

            set
            {
                _JobType = value;
            }
        }
        private int _JobTypeID = 0;
        [Column(Storage = "_JobTypeID", Name = "JobTypeID")]
        public int JobTypeID
        {
            get

            { return _JobTypeID; }

            set
            {
                _JobTypeID = value;
            }
        }


        private int _LocationID = 0;
        [Column(Storage = "_LocationID", Name = "LocationID")]
        public int LocationID
        {
            get

            { return _LocationID; }

            set
            {
                _LocationID = value;
            }
        }


        private String _Status = "";
        [Column(Storage = "_Status", Name = "Status")]
        public String Status
        {
            get

            { return _Status; }

            set
            {
                _Status = value;
            }
        }

        private int _JobAdvTypeID = 0;
        [Column(Storage = "_JobAdvTypeID", Name = "JobAdvTypeID")]
        public int JobAdvTypeID
        {
            get

            { return _JobAdvTypeID; }

            set
            {
                _JobAdvTypeID = value;
            }
        }

        private String _JobAdvType = "";
        [Column(Storage = "_JobAdvType", Name = "JobAdvType")]
        public String JobAdvType
        {
            get

            { return _JobAdvType; }

            set
            {
                _JobAdvType = value;
            }
        }


    }


    [DataObject()]
    public class JobObject : IDisposable
    {

        JobRepoDataContext context = new JobRepoDataContext();
        public JobObject()
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
        public List<JobDto> GetJobs(string WhereClause)
        {
            string[] values = null;
            string Keywords = "";

            if (WhereClause != "")
            {
                var jobpredicate = PredicateBuilder.False<Job>();

                var citypredicate = PredicateBuilder.True<City>();

                JobAdvTypeObject jobAdvobj = new JobAdvTypeObject();
                var JobAdvTypes = jobAdvobj.GetAdvs();

                string[] filters = WhereClause.Split('&');
                foreach (string filter in filters)
                {
                    string[] where = filter.Split('=');
                    switch (where[0])
                    {
                        case "DD": //Description
                            Keywords = where[1];
                            values = where[1].Split(';');
  
                            foreach (string value in values)
                                jobpredicate = jobpredicate.Or(p => p.Description.Contains(value) || p.Title.Contains(value));

                           jobpredicate = jobpredicate.And(p => p.Status=="A");
                            break;
                        case "LL": //Locatin
                            values = where[1].Split(';');
                            if (values.Length > 0)
                            {
                                //http://zhino.blog.com/2012/02/15/in-clause-in-linq/
                                //JobAdvTypes = JobAdvTypes
                                //     .Where(e => values.Contains(e.ID.ToString()));
                                citypredicate = PredicateBuilder.False<City>();
                                foreach (string value in values)
                                    citypredicate = citypredicate.Or(p => p.CityName.Contains(value));
                            }
                            break;
                    }
                }

                //http://www.albahari.com/nutshell/linqkit.aspx
                var query = from job in context.Jobs.AsExpandable().Where(jobpredicate).AsEnumerable()
                            join adv in JobAdvTypes.AsEnumerable()  on job.JobAdvTypeID equals adv.ID
                            join loc in context.Locations.AsEnumerable() on job.LocationID equals loc.LocationID
                            join city in context.Cities.AsExpandable().Where(citypredicate).AsEnumerable() on loc.CityID equals city.CityID
                            
                            select new JobDto()
                            {
                                Description = job.Description,
                                ShortDescription = StripTagsRegex(job.Description),
                                EmployerID = job.EmployerID,
                                JobAdvType = city.CityName,
                                JobAdvTypeID = job.JobAdvTypeID,
                                JobID = job.JobID,
                                JobTypeID = job.JobTypeID,
                                LocationID = job.LocationID,
                                PostedDate = job.PostedDate,
                                SalaryFrom = job.SalaryFrom,
                                SalaryTo = job.SalaryTo,
                                Status = (job.Status == "U" ? "Unpaid" : job.Status == "E" ? "Expired" : "Active"),
                                Title = job.Title,
                                ValidFrom = job.ValidFrom,
                                ValidTo = job.ValidTo,
                                ValidationRange = "From " + job.ValidFrom.ToShortDateString() + " to " + job.ValidTo.ToShortDateString(),
                                SalaryRange = job.SalaryFrom + (String.IsNullOrEmpty(job.SalaryTo) ? "" : " _ " + job.SalaryTo)


                            };


                //Saving the selected keywords for providing online statistics later
                context.SetKeywordsPopularity(Keywords);

                return query.ToList();
            }
            else
                return null;

        }

        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<JobDto> GetJobsByEmployerID(int EmployerID)
        {
            JobAdvTypeObject jobAdvobj = new JobAdvTypeObject();
            var JobAdvTypes = jobAdvobj.GetAllActiveAdvs();


            var query = from job in context.Jobs.AsEnumerable()
                        join adv in JobAdvTypes.AsEnumerable() on job.JobAdvTypeID equals adv.ID
                        where job.EmployerID == EmployerID
                        select new JobDto()
                        {
                            Description = job.Description,
                            EmployerID = job.EmployerID,
                            JobAdvType = adv.Type,
                            JobAdvTypeID = job.JobAdvTypeID,
                            JobID = job.JobID,
                            JobTypeID = job.JobTypeID,
                            LocationID = job.LocationID,
                            PostedDate = job.PostedDate,
                            SalaryFrom = job.SalaryFrom,
                            SalaryTo = job.SalaryTo,
                            Status = (job.Status == "U" ? "Unpaid" : job.Status == "E" ? "Expired" : "Active"),
                            Title = job.Title,
                            ValidFrom = job.ValidFrom,
                            ValidTo = job.ValidTo,
                            ValidationRange = "From " + job.ValidFrom.ToShortDateString() + " to " + job.ValidTo.ToShortDateString(),
                            SalaryRange = job.SalaryFrom + (String.IsNullOrEmpty(job.SalaryTo) ? "" : " _ " + job.SalaryTo)


                        };

            return query.ToList();

        }

        //http://www.dotnetperls.com/remove-html-tags
        public static string StripTagsRegex(string source)
        {
            source = (source.Length > 200 ? source.Substring(0, 200) : source);
            source=  Regex.Replace(source, "<.*?>", string.Empty);
            return source + "...";
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<JobDto> GetJobByID(int JobID)
        {

            JobAdvTypeObject jobAdvobj = new JobAdvTypeObject();
        //    var JobAdvTypes = jobAdvobj.GetAllActiveAdvs();

            var query = from job in context.Jobs.AsEnumerable()
                        //                join adv in JobAdvTypes.AsEnumerable() on job.JobAdvTypeID equals adv.ID
                        join typ in context.JobTypes.AsEnumerable() on job.JobTypeID equals typ.JobTypeID
                        join loc in context.Locations.AsEnumerable() on job.LocationID equals loc.LocationID
                        join city in context.Cities.AsExpandable().AsEnumerable() on loc.CityID equals city.CityID
                        where job.JobID == JobID
                        select new JobDto
                        {
                            Description = job.Description,
                            ShortDescription = "",
                            EmployerID = job.EmployerID,
                            JobAdvType = city.CityName,
                            JobAdvTypeID = job.JobAdvTypeID,
                            JobID = job.JobID,
                            JobTypeID = job.JobTypeID,
                            LocationID = job.LocationID,
                            PostedDate = job.PostedDate,
                            SalaryFrom = job.SalaryFrom,
                            SalaryTo = job.SalaryTo,
                            Status = (job.Status == "U" ? "Unpaid" : job.Status == "E" ? "Expired" : "Active"),
                            Title = job.Title,
                            ValidFrom = job.ValidFrom,
                            ValidTo = job.ValidTo,
                            ValidationRange = "From " + job.ValidFrom.ToShortDateString() + " to " + job.ValidTo.ToShortDateString(),
                            SalaryRange = job.SalaryFrom + (String.IsNullOrEmpty(job.SalaryTo) ? "" : " _ " + job.SalaryTo),
                            JobType = typ.Description
                        };

            return query.ToList();

        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int InsertJob(JobDto jobdto)
        {
            try
            {
                Job job = new Job()
                {
                    Description = jobdto.Description,
                    EmployerID = jobdto.EmployerID,
                    JobAdvTypeID = jobdto.JobAdvTypeID,
                    JobID = jobdto.JobID,
                    JobTypeID = jobdto.JobTypeID,
                    LocationID = jobdto.LocationID,
                    PostedDate = jobdto.PostedDate,
                    SalaryFrom = jobdto.SalaryFrom,
                    SalaryTo = jobdto.SalaryTo,
                    Status = jobdto.Status,
                    Title = jobdto.Title,
                    ValidFrom = jobdto.ValidFrom,
                    ValidTo = jobdto.ValidTo
                };
                context.Jobs.AddObject(job);


                context.SaveChanges();


                return job.JobID;
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteJob(JobDto jobdto)
        {
            try
            {
                Job origJob = context.Jobs
                .FirstOrDefault(e => e.JobID == jobdto.JobID);
                if (origJob == null)
                    context.Jobs.Attach(origJob);

                context.Jobs.DeleteObject(origJob);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateJob(JobDto jobdto)
        {
            try
            {


                
                Job origJob = context.Jobs
                    .FirstOrDefault(e => e.JobID == jobdto.JobID);
                if (origJob != null)
                {
                    
                    
                        origJob.Description = jobdto.Description;                       
                        origJob.JobAdvTypeID = jobdto.JobAdvTypeID;                     
                        origJob.JobTypeID = jobdto.JobTypeID;
                        origJob.LocationID = jobdto.LocationID;
                        origJob.SalaryFrom = jobdto.SalaryFrom;
                        origJob.SalaryTo = jobdto.SalaryTo;
                        origJob.Status = jobdto.Status;
                        origJob.Title = jobdto.Title;
                        origJob.ValidFrom = jobdto.ValidFrom;
                        origJob.ValidTo = jobdto.ValidTo;

                        context.ApplyCurrentValues("Jobs", origJob);
                }
                else
                    context.Jobs.Attach(origJob);
                

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }


    }

}