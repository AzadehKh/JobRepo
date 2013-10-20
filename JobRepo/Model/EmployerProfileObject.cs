using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Security;

namespace JobRepo.Model
{
    [DataObject()]
    public class EmployerProfileObject : IDisposable 
    {

        JobRepoDataContext context = new JobRepoDataContext();
        public EmployerProfileObject()
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
        public IEnumerable<Employer> GetProfile(string UserID)
        {
            if (UserID == null)
                return null;
            Guid ID = new Guid(UserID);
            return context.Employers
                .Where(e => e.UserID == ID)
                .ToList();
           

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int InsertEmployer(Employer employer)
        {
            try
            {

                context.Employers.AddObject(employer);

                context.SaveChanges();

                return employer.EmployerID;

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
        public void DeleteEmployer(Employer employer)
        {
            try
            {
             
                context.Employers.Attach(employer);
                context.Employers.DeleteObject(employer);
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
        public void UpdateEmployer(Employer employer)
        {
            try
            {

                Employer origEmployer = context.Employers
                    .FirstOrDefault(e => e.EmployerID == employer.EmployerID);
                if (origEmployer != null)
                {
                    context.ApplyCurrentValues("Employers", employer);
                }
                else
                    context.Employers.Attach(employer);

             //   context.Employers.Attach(origEmployer);
            //    context.ApplyCurrentValues("Employers", employer);

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