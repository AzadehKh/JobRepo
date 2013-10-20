using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Security;


namespace JobRepo.Model
{
    [DataObject()]
    public class EmployeeProfileObject : IDisposable 
    {

        JobRepoDataContext context = new JobRepoDataContext();
        public EmployeeProfileObject()
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
        public IEnumerable<Employee> FilterProfiler(string Keyword)
        {
            string[] filters = Keyword.Split(';');

            var emps = context.Resumes
                .Where ( p => filters.Any( x => p.Keywords.Contains(x)))
                .Select( e => e.Employee);

            return emps;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Employee> GetProfile(string UserID)
        {
            Guid ID = new Guid(UserID);
            return context.Employees
                .Where(e => e.UserID == ID)
                .ToList();
           

        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Employee> GetProfilebyID(int EmployeeID)
        {
            return context.Employees
                .Where(e => e.EmployeeID == EmployeeID)
                .ToList();


        }



        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int InsertEmployee(Employee Employee)
        {
            try
            {

                context.Employees.AddObject(Employee);

                context.SaveChanges();

                return Employee.EmployeeID;

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
        public void DeleteEmployee(Employee Employee)
        {
            try
            {
             
                context.Employees.Attach(Employee);
                context.Employees.DeleteObject(Employee);
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
        public void UpdateEmployee(Employee Employee)
        {
            try
            {

                Employee origEmployee = context.Employees
                    .FirstOrDefault(e => e.EmployeeID == Employee.EmployeeID);
                if (origEmployee != null)
                {
                    context.ApplyCurrentValues("Employees", Employee);
                }
                else
                    context.Employees.Attach(Employee);

             //   context.Employees.Attach(origEmployee);
            //    context.ApplyCurrentValues("Employees", Employee);

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