//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 27/09/2013 5:11:47 PM
namespace JobRepo.TopTenWcfDataServiceRef
{
    
    /// <summary>
    /// There are no comments for JobRepoDataContext in the schema.
    /// </summary>
    public partial class JobRepoDataContext : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new JobRepoDataContext object.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public JobRepoDataContext(global::System.Uri serviceRoot) : 
                base(serviceRoot)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("JobRepoModel", global::System.StringComparison.Ordinal))
            {
                return this.GetType().Assembly.GetType(string.Concat("JobRepo.TopTenWcfDataServiceRef", typeName.Substring(12)), false);
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("JobRepo.TopTenWcfDataServiceRef", global::System.StringComparison.Ordinal))
            {
                return string.Concat("JobRepoModel.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for Jobs in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Job> Jobs
        {
            get
            {
                if ((this._Jobs == null))
                {
                    this._Jobs = base.CreateQuery<Job>("Jobs");
                }
                return this._Jobs;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Job> _Jobs;
        /// <summary>
        /// There are no comments for Jobs in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToJobs(Job job)
        {
            base.AddObject("Jobs", job);
        }
    }
    /// <summary>
    /// There are no comments for JobRepoModel.Job in the schema.
    /// </summary>
    /// <KeyProperties>
    /// JobID
    /// </KeyProperties>
    [global::System.Data.Services.Common.DataServiceKeyAttribute("JobID")]
    public partial class Job
    {
        /// <summary>
        /// Create a new Job object.
        /// </summary>
        /// <param name="jobID">Initial value of JobID.</param>
        /// <param name="employerID">Initial value of EmployerID.</param>
        /// <param name="title">Initial value of Title.</param>
        /// <param name="description">Initial value of Description.</param>
        /// <param name="postedDate">Initial value of PostedDate.</param>
        /// <param name="validFrom">Initial value of ValidFrom.</param>
        /// <param name="validTo">Initial value of ValidTo.</param>
        /// <param name="jobTypeID">Initial value of JobTypeID.</param>
        /// <param name="locationID">Initial value of LocationID.</param>
        /// <param name="status">Initial value of Status.</param>
        /// <param name="jobAdvTypeID">Initial value of JobAdvTypeID.</param>
        /// <param name="viewed">Initial value of Viewed.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Job CreateJob(int jobID, int employerID, string title, string description, global::System.DateTime postedDate, global::System.DateTime validFrom, global::System.DateTime validTo, int jobTypeID, int locationID, string status, int jobAdvTypeID, int viewed)
        {
            Job job = new Job();
            job.JobID = jobID;
            job.EmployerID = employerID;
            job.Title = title;
            job.Description = description;
            job.PostedDate = postedDate;
            job.ValidFrom = validFrom;
            job.ValidTo = validTo;
            job.JobTypeID = jobTypeID;
            job.LocationID = locationID;
            job.Status = status;
            job.JobAdvTypeID = jobAdvTypeID;
            job.Viewed = viewed;
            return job;
        }
        /// <summary>
        /// There are no comments for Property JobID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int JobID
        {
            get
            {
                return this._JobID;
            }
            set
            {
                this.OnJobIDChanging(value);
                this._JobID = value;
                this.OnJobIDChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _JobID;
        partial void OnJobIDChanging(int value);
        partial void OnJobIDChanged();
        /// <summary>
        /// There are no comments for Property EmployerID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int EmployerID
        {
            get
            {
                return this._EmployerID;
            }
            set
            {
                this.OnEmployerIDChanging(value);
                this._EmployerID = value;
                this.OnEmployerIDChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _EmployerID;
        partial void OnEmployerIDChanging(int value);
        partial void OnEmployerIDChanged();
        /// <summary>
        /// There are no comments for Property Title in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this.OnTitleChanging(value);
                this._Title = value;
                this.OnTitleChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Title;
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        /// <summary>
        /// There are no comments for Property Description in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnDescriptionChanging(value);
                this._Description = value;
                this.OnDescriptionChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Description;
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        /// <summary>
        /// There are no comments for Property PostedDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime PostedDate
        {
            get
            {
                return this._PostedDate;
            }
            set
            {
                this.OnPostedDateChanging(value);
                this._PostedDate = value;
                this.OnPostedDateChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _PostedDate;
        partial void OnPostedDateChanging(global::System.DateTime value);
        partial void OnPostedDateChanged();
        /// <summary>
        /// There are no comments for Property ValidFrom in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime ValidFrom
        {
            get
            {
                return this._ValidFrom;
            }
            set
            {
                this.OnValidFromChanging(value);
                this._ValidFrom = value;
                this.OnValidFromChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _ValidFrom;
        partial void OnValidFromChanging(global::System.DateTime value);
        partial void OnValidFromChanged();
        /// <summary>
        /// There are no comments for Property ValidTo in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime ValidTo
        {
            get
            {
                return this._ValidTo;
            }
            set
            {
                this.OnValidToChanging(value);
                this._ValidTo = value;
                this.OnValidToChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _ValidTo;
        partial void OnValidToChanging(global::System.DateTime value);
        partial void OnValidToChanged();
        /// <summary>
        /// There are no comments for Property SalaryFrom in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string SalaryFrom
        {
            get
            {
                return this._SalaryFrom;
            }
            set
            {
                this.OnSalaryFromChanging(value);
                this._SalaryFrom = value;
                this.OnSalaryFromChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _SalaryFrom;
        partial void OnSalaryFromChanging(string value);
        partial void OnSalaryFromChanged();
        /// <summary>
        /// There are no comments for Property SalaryTo in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string SalaryTo
        {
            get
            {
                return this._SalaryTo;
            }
            set
            {
                this.OnSalaryToChanging(value);
                this._SalaryTo = value;
                this.OnSalaryToChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _SalaryTo;
        partial void OnSalaryToChanging(string value);
        partial void OnSalaryToChanged();
        /// <summary>
        /// There are no comments for Property JobTypeID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int JobTypeID
        {
            get
            {
                return this._JobTypeID;
            }
            set
            {
                this.OnJobTypeIDChanging(value);
                this._JobTypeID = value;
                this.OnJobTypeIDChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _JobTypeID;
        partial void OnJobTypeIDChanging(int value);
        partial void OnJobTypeIDChanged();
        /// <summary>
        /// There are no comments for Property LocationID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int LocationID
        {
            get
            {
                return this._LocationID;
            }
            set
            {
                this.OnLocationIDChanging(value);
                this._LocationID = value;
                this.OnLocationIDChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _LocationID;
        partial void OnLocationIDChanging(int value);
        partial void OnLocationIDChanged();
        /// <summary>
        /// There are no comments for Property Status in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this.OnStatusChanging(value);
                this._Status = value;
                this.OnStatusChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Status;
        partial void OnStatusChanging(string value);
        partial void OnStatusChanged();
        /// <summary>
        /// There are no comments for Property JobAdvTypeID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int JobAdvTypeID
        {
            get
            {
                return this._JobAdvTypeID;
            }
            set
            {
                this.OnJobAdvTypeIDChanging(value);
                this._JobAdvTypeID = value;
                this.OnJobAdvTypeIDChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _JobAdvTypeID;
        partial void OnJobAdvTypeIDChanging(int value);
        partial void OnJobAdvTypeIDChanged();
        /// <summary>
        /// There are no comments for Property Viewed in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Viewed
        {
            get
            {
                return this._Viewed;
            }
            set
            {
                this.OnViewedChanging(value);
                this._Viewed = value;
                this.OnViewedChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Viewed;
        partial void OnViewedChanging(int value);
        partial void OnViewedChanged();
    }
}